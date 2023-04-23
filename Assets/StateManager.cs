using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{   
    #region Attributes

        #region Money

        //Dinero al inicio del día (al guardar se debe guardar esta cantidad, por lo que el guardado reinicia el día actual)
        public float _moneyDayStart { get; private set; }
        public void SetMoneyDayStart(float money) {
            _moneyDayStart = money;
        }

        //Dinero ganado en el día
        public float _moneyDay { get; private set; }
        public void SetMoneyDay(float money) {
            _moneyDay = money;
        }

        #endregion

        #region Dias

        //Día actual
        public int _dia {get; private set;}
        public void SetDia(int dia) {
            _dia = dia;
        }

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
        public void SetEventos(Dictionary<int, List<Evento>> eventos) {
            _eventos = eventos;
        }

        #endregion

        #region Backpack

        //Backpack
        public struct Backpack //TODO maybe cambiar a clase, hacer con clase de items... etc
        {
            private int _maxItems;
            public int _numItems;
            public List<string> _items;
        }

        
        public Backpack _backpack {get; private set;}

        #endregion

    #endregion

    private void Start() {
        _moneyDayStart = 0;
        _moneyDay = 0;
        _dia = 1;
        _eventos = new Dictionary<int, List<Evento>>();
    }

    #region Useful Methods
    public void AddMoney(float money, string nombreEvento = "invalid", bool isVentas = false) {
        _moneyDay += money;
        if(nombreEvento != "invalid") {
            AddEvent(nombreEvento, money, isVentas);
        }
    }

    public float getTotalMoney() {
        return _moneyDayStart + _moneyDay;
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
    }

    public List<Evento> getEventsByDay(int dia) {
        if(_eventos.ContainsKey(dia)) {
            return _eventos[dia];
        }
        return null;
    }

    public List<Evento> getCurrentDayEvents()
    {
        return getEventsByDay(_dia);
    }

    public void loadState(int dia, float moneyDayStart, Dictionary<int, List<Evento>> eventos) {
        _dia = dia;
        _moneyDayStart = moneyDayStart;
        _moneyDay = 0;
        _eventos = eventos;
    }
    
    #endregion

}
