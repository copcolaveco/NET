Public Class dControlInformesSuelos

    Inherits dControlBase

#Region "Métodos ABM"
    Public Overrides Function guardar() As Boolean
        Dim c As New pControlInformesSuelos
        Return c.guardar(Me)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControlInformesSuelos
        Return c.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pControlInformesSuelos
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dControlInformesSuelos
        Dim c As New pControlInformesSuelos
        Return c.buscar(Me)
    End Function
    Public Function buscarxficha() As dControlInformesSuelos
        Dim c As New pControlInformesSuelos
        Return c.buscarxficha(Me)
    End Function

#End Region

    'Public Overrides Function tostring() As String
    '    Return m_ficha
    'End Function
    Public Function listar() As ArrayList
        Dim c As New pControlInformesSuelos
        Return c.listar
    End Function
    Public Overrides Function listarxfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pControlInformesSuelos
        Return c.listarxfecha(desde, hasta)
    End Function
    Public Overrides Function listarxtipoxfecha(ByVal tipo As String, ByVal desde As String, ByVal hasta As String, ByVal ficha As Long) As ArrayList
        Dim c As New pControlInformesSuelos
        Return c.listarxtipoxfecha(tipo, desde, hasta, ficha)
    End Function
    Public Function listarxfechanc(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pControlInformesSuelos
        Return c.listarxfechanc(desde, hasta)
    End Function
    Public Function listarxfechaom(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim c As New pControlInformesSuelos
        Return c.listarxfechaom(desde, hasta)
    End Function
    Public Overrides Function marcarresultado(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesSuelos
        Return ci.marcarresultado(Me, usuario)
    End Function
    Public Function desmarcarresultado(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesSuelos
        Return ci.desmarcarresultado(Me, usuario)
    End Function
    Public Function marcarcoincide(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesSuelos
        Return ci.marcarcoincide(Me, usuario)
    End Function
    Public Function desmarcarcoincide(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesSuelos
        Return ci.desmarcarcoincide(Me, usuario)
    End Function
    Public Function marcarom(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesSuelos
        Return ci.marcarom(Me, usuario)
    End Function
    Public Function desmarcarom(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesSuelos
        Return ci.desmarcarom(Me, usuario)
    End Function
    Public Function marcarnc(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesSuelos
        Return ci.marcarnc(Me, usuario)
    End Function
    Public Function desmarcarnc(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesSuelos
        Return ci.desmarcarnc(Me, usuario)
    End Function
    Public Function marcarcontrolada(ByVal usuario As dUsuario) As Boolean
        Dim ci As New pControlInformesSuelos
        Return ci.marcarcontrolada(Me, usuario)
    End Function
    Public Function guardarobservaciones(ByVal usuario As dUsuario, ByVal obs As String) As Boolean
        Dim ci As New pControlInformesSuelos
        Return ci.guardarobservaciones(Me, usuario, obs)
    End Function
    Public Overrides Function lstConNom(ByVal Ficha As Long) As dControlBase
        Dim c As New pControlInformesSuelos
        Return c.lstConNom(FICHA)
    End Function
End Class
