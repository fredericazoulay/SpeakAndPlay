using SpeakAndSpell.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakAndSpell.Helpers.DesignPatterns
{
    public class Singletons //UserWindow
    {
        //       #region Fields
        //
        //       /// <summary>_rightsSelected</summary>
        //       private IUserWindow _selectedWindow;
        //
        //       /// <summary>_Lock</summary>
        //       static object _Lock = new object();
        //       /// <summary>_Instance</summary>
        //       static UserWindow _Instance;
        //       #endregion
        //
        //       #region Methods
        //       /// <summary>Singleton Instance</summary>
        //       public static UserWindow Instance
        //       {
        //           get
        //           {
        //               lock (_Lock)
        //               {
        //                   if (_Instance == null)
        //                   {
        //                       _Instance = new UserWindow();
        //                   }
        //                   return _Instance;
        //               }
        //           }
        //       }
        //
        //       public class Singleton
        //       {
        //           private static Singleton instance;
        //
        //           private Singleton() { }
        //
        //           public static Singleton Instance
        //           {
        //               get
        //               {
        //                   if (instance == null)
        //                   {
        //                       instance = new Singleton();
        //                   }
        //                   return instance;
        //               }
        //           }
        //       }
        //       #endregion

        /// <summary>
        /// SingletonSpeakAndMath
        /// </summary>
        public class SingletonSpeakAndMath
        {
            private static SpeakAndMath instance;

            private SingletonSpeakAndMath() { }

            public static SpeakAndMath Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new SpeakAndMath();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// SingletonSpeakAndMusic
        /// </summary>
        public class SingletonSpeakAndMusic
        {
            private static SpeakAndMusic instance;

            private SingletonSpeakAndMusic() { }

            public static SpeakAndMusic Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new SpeakAndMusic();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// SingletonSpeakAndRead
        /// </summary>
        public class SingletonSpeakAndRead
        {
            private static SpeakAndRead instance;

            private SingletonSpeakAndRead() { }

            public static SpeakAndRead Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new SpeakAndRead();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// SingletonSpeakAndSpell
        /// </summary>
        public class SingletonSpeakAndSpell
        {
            private static SpeakAndSpell.View.SpeakAndSpell instance;

            private SingletonSpeakAndSpell() { }

            public static SpeakAndSpell.View.SpeakAndSpell Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new SpeakAndSpell.View.SpeakAndSpell();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// SingletonSpeakAndTranslate
        /// </summary>
        public class SingletonSpeakAndTranslate
        {
            private static SpeakAndTranslate instance;

            private SingletonSpeakAndTranslate() { }

            public static SpeakAndTranslate Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new SpeakAndTranslate();
                    }
                    return instance;
                }
            }
        }

    }
}
