using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MLApps.Capstone.Encriptado.Transversal.Common.Extensions
{
    public static class MyTaskExtensions
    {
        /// <summary>
        /// Configura un awaiter para esperar una tarea determinada y captura el contexto actual para asegurarse de que
        /// el código subsiguiente se ejecuta en el mismo contexto, es decir en el hilo pincipal.
        /// Es recomendable este tipo de ejecucion para cuando la UI de usuario espera por el resultado.
        /// Igual a .ConfigureAwait(true).
        /// </summary>
        /// <param name="task">La tarea para configurar el awaiter</param>
        /// <returns>Un objeto usado para esperar esta tarea. <see cref="ConfiguredTaskAwaitable"/></returns>
        public static ConfiguredTaskAwaitable ConfigureAwaitTrue(this Task task)
        {
            return task.ConfigureAwait(true);
        }

        /// <summary>
        /// Configura un awaiter para esperar una tarea determinada y captura el contexto actual para asegurarse de que
        /// el código subsiguiente se ejecuta en el mismo contexto, es decir en el hilo pincipal.
        /// Es recomendable este tipo de ejecucion para cuando la UI de usuario espera por el resultado.
        /// Igual a .ConfigureAwait(true).
        /// </summary>
        /// <typeparam name="T">El tipo del resultado de la tarea a esperar</typeparam>
        /// <param name="task">La tarea para configurar el awaiter</param>
        /// <returns>Un objeto usado para esperar esta tarea. <see cref="ConfiguredTaskAwaitable"/></returns>
        public static ConfiguredTaskAwaitable<T> ConfigureAwaitTrue<T>(this Task<T> task)
        {
            return task.ConfigureAwait(true);
        }

        /// <summary>
        /// Configura un awaiter para esperar una tarea determinada sin capturar un contexto. Esto significa que
        /// Es probable que el código subsiguiente se ejecute en otro contexto distinto del que se llamó a la tarea esperada.
        /// Debe usar este método en casi todos los métodos esperados. Pero preste atención si su código asíncrono está estrechamente vinculado a una interfaz de usuario (UI).
        /// Igual a .ConfigureAwait(falso).
        /// </summary>
        /// <param name="task">La tarea para configurar el awaiter</param>
        /// <returns>Un objeto usado para esperar esta tarea. <see cref="ConfiguredTaskAwaitable"/></returns>
        public static ConfiguredTaskAwaitable ConfigureAwaitFalse(this Task task)
        {
            return task.ConfigureAwait(false);
        }

        /// <summary>
        /// Configura un awaiter para esperar una tarea determinada sin capturar un contexto. Esto significa que
        /// Es probable que el código subsiguiente se ejecute en otro contexto distinto del que se llamó a la tarea esperada.
        /// Debe usar este método en casi todos los métodos esperados. Pero preste atención si su código asíncrono está estrechamente vinculado a una interfaz de usuario (UI).
        /// Igual a .ConfigureAwait(falso).
        /// </summary>
        /// <typeparam name="T">El tipo del resultado de la tarea a esperar</typeparam>
        /// <param name="task">La tarea para configurar el awaiter</param>
        /// <returns>Un objeto usado para esperar esta tarea. <see cref="ConfiguredTaskAwaitable"/></returns>
        public static ConfiguredTaskAwaitable<T> ConfigureAwaitFalse<T>(this Task<T> task)
        {
            return task.ConfigureAwait(false);
        }
    }
}
