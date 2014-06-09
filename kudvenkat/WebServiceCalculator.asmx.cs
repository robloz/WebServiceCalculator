using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace kudvenkat
{
    /// <summary>
    /// Summary description for WebServiceCalculator
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/WebServiceCalculator")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceCalculator : System.Web.Services.WebService
    {
        public enum EnumOperationBi { Add, Sub, Mul, Div };

        public struct DataOperation
        {
            public float firstNumber;
            public float secondNumber;
            public float result;
            public EnumOperationBi enumOper;
        }

       
       // enum EnumOperationUn { ToThink };

        List<Func<float, float, float>> l_operBi = new List<Func<float,float,float>>();
       // List<Func<>>

        public WebServiceCalculator()
        {

            l_operBi = new List<Func<float, float, float>>(
                
               // Enum.GetNames(typeof(EnumOperationBi)).Length
                
               new Func<float, float, float>[
                   Enum.GetNames(typeof(EnumOperationBi)).Length  // la reserva de memoria se hace de esta forma
                   ]

                );



            Console.WriteLine(l_operBi.Count);

            l_operBi[(int)EnumOperationBi.Add] = delegate(float firstNumber, float secondNumber) { return firstNumber + secondNumber; };
            l_operBi[(int)EnumOperationBi.Sub] = delegate(float firstNumber, float secondNumber) { return firstNumber - secondNumber; };
            l_operBi[(int)EnumOperationBi.Mul] = delegate(float firstNumber, float secondNumber) { return firstNumber * secondNumber; };
            l_operBi[(int)EnumOperationBi.Div] = delegate(float firstNumber, float secondNumber) { return firstNumber / secondNumber; };
        
        
        
        }

        private void AddOperationInLog(float firstNumber, float secondNumber, float result, EnumOperationBi operation)
        {
            DataOperation dataOperation;
            List<DataOperation> list_log = (List<DataOperation>)Session["LogOperations"];

            if (list_log == null)
            {
                Session["LogOperations"] = new List<DataOperation>();
                list_log = (List<DataOperation>)Session["LogOperations"];
            }

            dataOperation.firstNumber = firstNumber;
            dataOperation.secondNumber = secondNumber;
            dataOperation.result = result;
            dataOperation.enumOper = operation;

            list_log.Add(dataOperation);
        }

        private List<string> GetListStringLog()
        {
            List<DataOperation> list_log = (List<DataOperation>)Session["LogOperations"];

            if (list_log == null)
            {
                List<string> l = new List<string>();
                l.Add("No operations");
                return l;
            }
            else
            {
                List<string> l_stringLog = new List<string>();

                foreach (DataOperation dataLog in list_log)
                {
                    string operation_st = "";
                    switch (dataLog.enumOper)
                    {
                        case EnumOperationBi.Add:
                            operation_st = "+";
                            break;
                        case EnumOperationBi.Sub:
                            operation_st = "-";
                            break;
                        case EnumOperationBi.Mul:
                            operation_st = "*";
                            break;
                        case EnumOperationBi.Div:
                            operation_st = "/";
                            break;
                    }

                    l_stringLog.Add(dataLog.firstNumber.ToString() + " " + operation_st + " " + dataLog.secondNumber.ToString() + " = " + dataLog.result.ToString());
                }

                return l_stringLog;

            }

        }

        /*
A Web service is a method of communication between two electronic devices over a network. This 2 devices do not share sessions or any other server information besides those expilicitly defined by the web service signature.

You have to remember that any device can access you web service and it this access should not depends on the language the it is using.

As a result, you should add all the information you want to share via in the response you give.
         **/

        // Web services are stateless or everytime you call web service it will create a new instance of it. That's why its not allowed to use session in constructor.

        [WebMethod(EnableSession=true)]
        public float ExecuteOperation(float firstNumber, float secondNumber, EnumOperationBi operation)
        {
            float result = l_operBi[(int)operation]( firstNumber, secondNumber);
            AddOperationInLog(firstNumber, secondNumber, result, operation);

            return result;
        }

        [WebMethod(EnableSession = true)]
        public int Add(int firstNumber, int secondNumber)
        {
            float result = firstNumber + secondNumber;
            AddOperationInLog(firstNumber, secondNumber, result, EnumOperationBi.Add);

            return (int)result;
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetLogOperations()
        {
            return GetListStringLog();

        }

    }
}
