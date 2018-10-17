using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Plugin.BluetoothLE;

namespace Sound_Track_Win
{
    namespace BluetoothLocation
    {
        class BluetoothTracking
        {
            Thread backgroundScan;
            AbstractAdapter scanningAdapter;
            BtScanObserver scanObserver;
            List<ScanResult> scanResults = new List<ScanResult>();
            IScanResult something;
            ScanResult somethingElse;

                
            public BluetoothTracking()
            {
                scanningAdapter.Scan().Subscribe(scanObserver);
            }

            public class BtScanObserver : IObserver<IScanResult>
            {
                List<ScanResult> currentScanResults;

                public List<ScanResult> LoadScannedResults()
                {
                    List<ScanResult> resultsToReturn = currentScanResults;
                    currentScanResults.Clear();
                    return resultsToReturn;

                }

                public void OnNext(IScanResult result)
                {

                }

                public void OnError(Exception e)
                {

                }

                public void OnCompleted()
                {

                }
            }

            

        }

        class BluetoothSmartSwap
        {

        }
    }
}
