using System;
using System.Collections.Generic;
using System.Web.Services;

namespace CalculatorClient
{
    [WebService(Namespace = "http://tempuri.org/WebServiceCalculator")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebServiceCalculator : WebService
    {
        public enum EnumOperationBi { Add, Sub, Mul, Div };

        public struct DataOperation
        {
            public float firstNumber;
            public float secondNumber;
            public float result;
            public EnumOperationBi enumOper;
        }

        private List<Func<float, float, float>> l_operBi = new List<Func<float,float,float>>();

        public WebServiceCalculator()
        {
            var totalOperations = Enum.GetNames(typeof(EnumOperationBi)).Length;
            l_operBi = new List<Func<float, float, float>>(new Func<float, float, float>[totalOperations]);

            l_operBi[(int)EnumOperationBi.Add] = delegate(float firstNumber, float secondNumber) { return firstNumber + secondNumber; };
            l_operBi[(int)EnumOperationBi.Sub] = delegate(float firstNumber, float secondNumber) { return firstNumber - secondNumber; };
            l_operBi[(int)EnumOperationBi.Mul] = delegate(float firstNumber, float secondNumber) { return firstNumber * secondNumber; };
            l_operBi[(int)EnumOperationBi.Div] = delegate(float firstNumber, float secondNumber) { return firstNumber / secondNumber; };
        }

        private void AddOperationInLog(float firstNumber, float secondNumber, float result, EnumOperationBi operation)
        {
            DataOperation dataOperation;
            var list_log = (List<DataOperation>)Session["LogOperations"];

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
            var log = (List<DataOperation>)Session["LogOperations"];

            if (log == null)
            {
                return new List<string> { "No operations" };
            }

            var resultLog = new List<string>();

            foreach (var dataLog in log)
            {
                string operation;

                switch (dataLog.enumOper)
                {
                    case EnumOperationBi.Add:
                        operation = "+";
                        break;
                    case EnumOperationBi.Sub:
                        operation = "-";
                        break;
                    case EnumOperationBi.Mul:
                        operation = "*";
                        break;
                    case EnumOperationBi.Div:
                        operation = "/";
                        break;
                    default:
                        throw new ArgumentException("Invalid operation");
                }

                resultLog.Add(string.Format("{0} {1} {2} = {3}", dataLog.firstNumber, operation, dataLog.secondNumber, dataLog.result));
            }

            return resultLog;
        }

        [WebMethod(EnableSession=true)]
        public float ExecuteOperation(float firstNumber, float secondNumber, EnumOperationBi operation)
        {
            try
            {
                var result = l_operBi[(int)operation]( firstNumber, secondNumber);

                AddOperationInLog(firstNumber, secondNumber, result, operation);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetLogOperations()
        {
            return GetListStringLog();
        }
    }
}