Public Class dFichasenMasa
#Region "Atributos"
    Private m_ficha As Long
#End Region

#Region "Getters y Setters"
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_ficha = 0
    End Sub
    Public Sub New(ByVal ficha As Long)
        m_ficha = ficha
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function eliminar() As Boolean
        Dim p As New pFichasenMasa
        Return p.eliminar(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_ficha
    End Function

    Public Function listar() As ArrayList
        Dim p As New pFichasenMasa
        Return p.listar
    End Function
End Class
