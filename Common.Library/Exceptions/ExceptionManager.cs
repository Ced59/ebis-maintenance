using System;

namespace Common.Classes
{
    public class ExceptionManager : Base
    {
        private static ExceptionManager _Instance;

        public static ExceptionManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExceptionManager();
                }

                return _Instance;
            }
            set { _Instance = value; }
        }

        public virtual void Publish(Exception ex)
        {
            // TODO: implémentation du publisher d'exceptions
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    }
}