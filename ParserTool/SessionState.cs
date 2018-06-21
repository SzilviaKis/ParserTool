using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ParserTool
{
    public static class HttpContextFacade
    {
        /// <summary>
        /// Default getter sets HttpContext.Current as managed HttpContext
        /// </summary>
        private static Func<HttpContextBase> _getter = () => new HttpContextWrapper(HttpContext.Current);

        /// <summary>
        /// wrapped HttpContext object
        /// </summary>
        public static HttpContextBase CurrentHttpContext => _getter();

        /// <summary>
        /// Use this method if you want to mock HttpContext
        /// </summary>
        /// <param name="getter"></param>
        public static void SetContext(Func<HttpContextBase> getter)
        {
            _getter = getter;
        }

        /// <summary>
        /// Property for accessing SessionState object
        /// </summary>
        public static SessionState SessionState
        {
            get
            {
                return (SessionState)CurrentHttpContext?.Session?["SessionState"];
            }
            set
            {
                if (CurrentHttpContext?.Session != null)
                    CurrentHttpContext.Session["SessionState"] = value;
            }
        }
    }

      /// <summary>
        /// Session state.
        /// </summary>
        public class SessionState
        {
            public Nullable<int> CurrentAccountId { get; set; }
            public string CurrentUserName { get; set; }

            public SessionState()
            {
                // Generate new session id
                SessionId = Guid.NewGuid();
                Data = new Dictionary<string, object>();
            }

            /// <summary>
            /// The current SessionState instance.
            /// </summary>
            public static SessionState Current
            {
                get
                {
                    return HttpContextFacade.SessionState;
                }
                set
                {
                    HttpContextFacade.SessionState = value;
                }
            }

            /// <summary>
            /// Miscellaneous data
            /// </summary>
            public Dictionary<string, object> Data { get; set; }

            /// <summary>
            /// Session identifier.
            /// </summary>
            public Guid SessionId { get; set; }

            /// <summary>
            /// Initializes the session state
            /// </summary>
            public static void InitSessionState()
            {
                Current = new SessionState();
            }
        }
    }
