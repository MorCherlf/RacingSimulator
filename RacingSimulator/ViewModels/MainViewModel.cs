using System;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using RacingSimulator.Services;
using RacingSimulator.Transports;
using RacingSimulator.Models;
using RacingSimulator.Weather;
using Avalonia.Media;
using System.Windows.Input;

namespace RacingSimulator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _selectedRaceType;
        private double _distance;
        private string _selectedTransport;
        private string _selectedWeather;
        private string _result;
        private ObservableCollection<ITransport> _participants;
        private ObservableCollection<string> _availableTransports;
        private ObservableCollection<string> _raceTypes;
        private ObservableCollection<string> _weathers;
        private Race _race;

        public MainViewModel()
        {
            Participants = new ObservableCollection<ITransport>();
            AvailableTransports = new ObservableCollection<string>
            {
                "Broomstick", "FlyingCarpet", "BootsOfSwiftness", "PumpkinCarriage", "Centaur", "FlyingShip", "BabaYagaHut"
            };
            RaceTypes = new ObservableCollection<string>
            {
                "Land Race", "Air Race", "Mix Race"
            };
            Weathers = new ObservableCollection<string>
            {
                "Sunny", "Rainy", "Windy", "Foggy"
            };
            AddParticipantCommand = ReactiveCommand.Create(AddParticipant);
            ClearParticipantsCommand = ReactiveCommand.Create(ClearParticipants);
            RemoveParticipantCommand = ReactiveCommand.Create<ITransport>(RemoveParticipant);
            StartRaceCommand = ReactiveCommand.Create(StartRace);
        }

        public ObservableCollection<ITransport> Participants
        {
            get => _participants;
            set => this.RaiseAndSetIfChanged(ref _participants, value);
        }

        public ObservableCollection<string> AvailableTransports
        {
            get => _availableTransports;
            set => this.RaiseAndSetIfChanged(ref _availableTransports, value);
        }

        public ObservableCollection<string> RaceTypes
        {
            get => _raceTypes;
            set => this.RaiseAndSetIfChanged(ref _raceTypes, value);
        }
        public ObservableCollection<string> Weathers
        {
            get => _weathers;
            set => this.RaiseAndSetIfChanged(ref _weathers, value);
        }

        public string SelectedRaceType
        {
            get => _selectedRaceType;
            set => this.RaiseAndSetIfChanged(ref _selectedRaceType, value);
        }

        public double Distance
        {
            get => _distance;
            set => this.RaiseAndSetIfChanged(ref _distance, value);
        }

        public string SelectedTransport
        {
            get => _selectedTransport;
            set => this.RaiseAndSetIfChanged(ref _selectedTransport, value);
        }

        public string SelectedWeather
        {
            get => _selectedWeather;
            set => this.RaiseAndSetIfChanged(ref _selectedWeather, value);
        }

        public string Result
        {
            get => _result;
            set => this.RaiseAndSetIfChanged(ref _result, value);
        }

        public ReactiveCommand<Unit, Unit> AddParticipantCommand { get; }
        public ReactiveCommand<Unit, Unit> ClearParticipantsCommand { get; }
        public ReactiveCommand<ITransport, Unit> RemoveParticipantCommand { get; }
        public ReactiveCommand<Unit, Unit> StartRaceCommand { get; }

        private void AddParticipant()
        {
            if (string.IsNullOrEmpty(SelectedTransport)) return;

            ITransport transport = SelectedTransport switch
            {
                "Broomstick" => new Broomstick(),
                "FlyingCarpet" => new FlyingCarpet(),
                "BootsOfSwiftness" => new BootsOfSwiftness(),
                "PumpkinCarriage" => new PumpkinCarriage(),
                "Centaur" => new Centaur(),
                "FlyingShip" => new FlyingShip(),
                "BabaYagaHut" => new BabaYagaHut(),
                _ => throw new InvalidOperationException("Unexpected Vehicle")
            };

            if (transport != null)
            {
                Participants.Add(transport);
            }
        }

        private void ClearParticipants()
        {
            Participants.Clear();
        }

        private void RemoveParticipant(ITransport transport)
        {
            if (Participants.Contains(transport))
            {
                Participants.Remove(transport);
            }
        }

        private void StartRace()
        {
            Type raceTypeType = SelectedRaceType switch
            {
                "Land Race" => typeof(LandTransport),
                "Air Race" => typeof(AirTransport),
                "Mix Race" => typeof(ITransport),
                _ => throw new InvalidOperationException("Unknown Race Type")
            };

            WeatherCondition weather = SelectedWeather switch
            {
                "Sunny" => new WeatherCondition(WeatherType.Sunny),
                "Rainy" => new WeatherCondition(WeatherType.Rainy),
                "Windy" => new WeatherCondition(WeatherType.Windy),
                "Foggy" => new WeatherCondition(WeatherType.Foggy),
                _ => throw new InvalidOperationException("Unknown Weather")
            };

            try
            {
                _race = new Race(Distance, raceTypeType, weather);

                foreach (var participant in Participants)
                {
                    _race.AddParticipant(participant);
                }

                var (winner, time) = _race.Start();
                Result = $"The Winner is: {winner.Name}，Total Time: {time.ToString("0.00")} \n Weather: {weather.Type}";
            }
            catch (Exception ex)
            {
                Result = $"Exception: {ex.Message}";
            }
        }
    }
}
