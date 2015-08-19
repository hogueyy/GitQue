Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.IO

Namespace CData.MongoDB.Demo
  NotInheritable Class Program
    Private Sub New()
    End Sub
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread> _
    Private Shared Sub Main()
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New GenerationForm())
    End Sub
  End Class
End Namespace