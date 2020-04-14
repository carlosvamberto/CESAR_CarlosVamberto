using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace cesar.android.service
{
    [Service(Exported = true, Name = "cesar.android.servicetest", IsolatedProcess = true)]
    public class CesarService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            string listJeson = intent.GetStringExtra("listJson");
            LinkedList<string> emailLinkedList = JsonConvert.DeserializeObject<LinkedList<string>>(listJeson);
            LinkedList<string> linkedListResult = utils.Tools.RemoveDuplicates(emailLinkedList);
            string result = JsonConvert.SerializeObject(linkedListResult);

            return base.OnStartCommand(intent, flags, startId);
        }        

        public override bool StopService(Intent name)
        {
            return base.StopService(name);
        }
    }
}