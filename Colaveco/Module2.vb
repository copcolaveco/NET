Imports System
Imports System.Net
Imports System.IO

Module Module2
    Sub Main()
        Dim sURL As String
        'sURL = "http://www.microsoft.com"
        sURL = "http://colaveco-gestor.herokuapp.com/users"
        Dim wrGETURL As WebRequest
        wrGETURL = WebRequest.Create(sURL)

        'Dim myProxy As New WebProxy("myproxy", 80)
        'myProxy.BypassProxyOnLocal = True

        ''wrGETURL.Proxy = myProxy
        'wrGETURL.Proxy = WebProxy.GetDefaultProxy()

        Dim objStream As Stream
        objStream = wrGETURL.GetResponse.GetResponseStream()

        Dim objReader As New StreamReader(objStream)
        Dim sLine As String = ""
        Dim i As Integer = 0

        Do While Not sLine Is Nothing
            i += 1
            sLine = objReader.ReadLine
            If Not sLine Is Nothing Then
                Console.WriteLine("{0}:{1}", i, sLine)
            End If
        Loop

        Console.ReadLine()

    End Sub
End Module
