using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени интерфейса "IService" в коде и файле конфигурации.
[ServiceContract]
public interface IService
{
    // Описываем сигнатурки, которые будут определять данные, которыми могут обмениваться клиент с сервером
    [OperationContract]
    ConcurrentDictionary<string, int> ParallelParse(string[] fContent);
}

