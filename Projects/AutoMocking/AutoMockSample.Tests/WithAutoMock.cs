using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;

namespace AutoMockSample.Tests
{
    public class WithAutoMock
    {
        private readonly Dictionary<Type, object> _list = new Dictionary<Type, object>();
        
        /// <summary>
        /// Gibt einen Fake für den angegebenen Type zurück.
        /// </summary>
        /// <typeparam name="T">Typ des angeforderten Fakes</typeparam>
        /// <returns>Instanz des angeforderten Fakes</returns>
        public T The<T>() where T : class
        {
            if (!_list.ContainsKey(typeof(T)))
                _list.Add(typeof(T), CreateMock(typeof(T)));
            return (T)_list[typeof(T)];
        }

        /// <summary>
        /// Erzeugt eine Instanz eines Types.
        /// Alle Konstruktorparameter werden durch Fakes oder registrierte Instanzen (<see cref="UseInstanceInsteadOfMock{TInterface,TImplementation}"/>) gefüllt.
        /// </summary>
        /// <typeparam name="T">Typ der Klasse welche erstellt werden soll</typeparam>
        /// <returns>Objekt vom Typ der Klasse welche erstellt werden soll</returns>
        public T CreateInstance<T>() where T : class
        {
            var constructor = typeof(T).GetConstructors().First();
            var constructorValues = new List<object>();
            foreach (var param in constructor.GetParameters())
            {
                var dependencyType = param.ParameterType;
                if (!_list.ContainsKey(dependencyType))
                    _list.Add(dependencyType, CreateMock(dependencyType));
                var instance = _list[dependencyType];
                constructorValues.Add(instance);
            }

            return (T)constructor.Invoke(constructorValues.ToArray());
        }

        private static object CreateMock(Type dependencyType)
        {
            return Substitute.For(new[] {dependencyType}, null);
        }
        
        /// <summary>
        /// Registriert eine Instanz für das angegebene Interface.
        /// Wird eine Implementierung eines Interfaces angefordert, wird diese Instanz verwendet anstatt einen Mock zu erzeugen.
        /// </summary>
        /// <typeparam name="TInterface">Interface unter welchem die Instanz registriert wird.</typeparam>
        /// <typeparam name="TImplementation">Instanz einer Implementierung des Interfaces.</typeparam>
        /// <param name="instance"></param>
        public void UseInstanceInsteadOfMock<TInterface, TImplementation>(TImplementation instance) where TImplementation : TInterface
        {
            if (_list.ContainsKey(typeof(TInterface)))
                throw new Exception($"An instance ({typeof(TImplementation)}) is already defined for type {typeof(TInterface)}.");

            _list.Add(typeof(TInterface), instance);
        }
    }
}