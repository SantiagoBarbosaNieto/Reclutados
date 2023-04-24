using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class GameStateManager : MonoBehaviour
{   
    public static GameStateManager Instance {get; private set;}

    private void Start() {
        _moneyDayStart = 0;
        _moneyDay = 0;
        _dia = 1;
        _collaborations = 0;
        _endBranch = 0;
        _eventos = new Dictionary<int, List<Evento>>();
    }

    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }
    #region EventosLlamados
        [SerializeField]
        public GameEvent UpdateUIEvent;
    #endregion

    #region Attributes

        #region Money

        //Dinero al inicio del día (al guardar se debe guardar esta cantidad, por lo que el guardado reinicia el día actual)
        public float _moneyDayStart { get; private set; }

        //Dinero ganado en el día
        public float _moneyDay { get; private set; }

        #endregion

        #region Dias

        //Día actual
        public int _dia {get; private set;}

        #endregion
    
        #region Eventos

        //Estructura que representa un evento que añadió o quitó dinero
        public struct Evento
        {
            public string _nombre;
            public float _valor;

            public bool isVentas;
        }

        //Diccionario de eventos por día
        public Dictionary<int, List<Evento>> _eventos {get; private set;}

        public bool _roadEventHappened {get; private set;}


        #endregion

        #region Backpack

        //Backpack
        public struct Backpack //TODO maybe cambiar a clase, hacer con clase de items... etc
        {
            public int _maxItems;
            public int _numItems;
            public List<string> _items;
        }

        
        public Backpack _backpack {get; private set;}

        #endregion

        #region EndState
        public int _endBranch {get; private set;}
        public int _collaborations {get; private set;}

        #endregion
        
        #region Persistance
            public bool _isDayLoaded {get; private set;}
        #endregion
    
    #endregion

    #region Setters
        public void SetMoneyDayStart(float money) {
            _moneyDayStart = money;
            UpdateUIEvent.Raise();
        }

        public void SetMoneyDay(float money) {
            _moneyDay = money;
            UpdateUIEvent.Raise();
        }

        public void SetDia(int dia) {
            _dia = dia;
            UpdateUIEvent.Raise();
        }

        public void SetEventos(Dictionary<int, List<Evento>> eventos) {
            _eventos = eventos;
        }

        public void SetRoadEventHappened(bool happened) {
            _roadEventHappened = happened;
        }

        public void SetBackpack(Backpack backpack) {
            _backpack = backpack;
        }

        public void SetEndBranch(int endBranch) {
            _endBranch = endBranch;
        }

        public void SetCollaborations(int collaborations) {
            this._collaborations = collaborations;
        }


        public void SetIsDayLoaded(bool isDayLoaded) {
            _isDayLoaded = isDayLoaded;
        }
    #endregion

    #region Additional Getters
        public float GetTotalMoney() {
            return _moneyDayStart + _moneyDay;
        }

        public List<Evento> GetEventsByDay(int dia) {
            if(_eventos.ContainsKey(dia)) {
                return _eventos[dia];
            }
            return null;
        }

        public List<Evento> GetCurrentDayEvents()
        {
            return GetEventsByDay(_dia);
        }

    #endregion

    #region Useful Methods
        public void AddMoney(AddMoney eventInfo) {
            //#TODO revisar si nombreEvento es válido 
            _moneyDay += eventInfo.money;
            AddEvent(eventInfo.description, eventInfo.money, eventInfo.isVentas);
            UpdateUIEvent.Raise();
        }


        private void AddEvent( string nombre, float valor, bool isVentas = false) {
            Evento evento = new Evento();
            evento._nombre = nombre;
            evento._valor = valor;
            evento.isVentas = isVentas;

            if(_eventos.ContainsKey(_dia)) {
                _eventos[_dia].Add(evento);
            }
            else {
                List<Evento> eventos = new List<Evento>();
                eventos.Add(evento);
                _eventos.Add(_dia, eventos);
            }
        }


        public void NextDay() {
            _moneyDayStart += _moneyDay;
            _moneyDay = 0;
            _dia++;
            _roadEventHappened = false;
            UpdateUIEvent.Raise();
        }

        public void ResetGameState()
        {
            _moneyDayStart = 0;
            _moneyDay = 0;
            _dia = 1;
            _collaborations = 0;
            _endBranch = 0;
            _eventos = new Dictionary<int, List<Evento>>();
            _roadEventHappened = false;
            UpdateUIEvent.Raise();
        }
        
        public void AddCollaboration() {
            _collaborations++;
        }

    #endregion

}
