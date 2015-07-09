using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tamagawa.EnmityPlugin
{

    public static class FFXIVProcessHelper
    {
        public static IList<Process> GetFFXIVProcessList()
        {
            return (
                from x in Process.GetProcessesByName("ffxiv")
                where !x.HasExited && x.MainModule != null && x.MainModule.ModuleName == "ffxiv.exe"
                select x).Union(
                from x in Process.GetProcessesByName("ffxiv_dx11")
                where !x.HasExited && x.MainModule != null && x.MainModule.ModuleName == "ffxiv_dx11.exe"
                select x).ToList<Process>();
        }

        public static Process GetFFXIVProcess(int pid = 0)
        {
            Process result;
            try
            {
                IList<Process> list = GetFFXIVProcessList();
                if (pid == 0)
                {
                    if (list.Any<Process>())
                    {
                        result = (
                            from x in list
                            orderby x.Id
                            select x).FirstOrDefault<Process>();
                    }
                    else
                    {
                        result = null;
                    }
                }
                else
                {
                    result = list.FirstOrDefault((Process x) => x.Id == pid);
                }
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }
}