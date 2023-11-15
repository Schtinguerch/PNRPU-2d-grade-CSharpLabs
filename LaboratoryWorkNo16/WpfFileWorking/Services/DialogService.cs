using Microsoft.Win32;

namespace WpfFileWorking.Services
{
    public class DialogService
    {
        public string OpenFileDialogPath()
        {
            return GetDialogPath(new OpenFileDialog { Multiselect = false });
        }

        public string SaveFileDialogPath()
        {
            return GetDialogPath(new SaveFileDialog());
        }
        
        private string GetDialogPath(FileDialog dialog)
        {
            dialog.RestoreDirectory = true;
            dialog.Filter = "JSON code (*.json)|*.json|All files (*.*)|*.*";
            dialog.FilterIndex = 1;

            return dialog.ShowDialog() == true ? dialog.FileName : null;
        }
    }
}