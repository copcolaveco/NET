Public Class dFactur
#Region "Atributos"
    Private m_facnro As Long ' número de movimiento
    Private m_facpdf As String ' path de la factura
   
#End Region

#Region "Getters y Setters"
    Public Property FACNRO() As Long
        Get
            Return m_facnro
        End Get
        Set(ByVal value As Long)
            m_facnro = value
        End Set
    End Property
    Public Property FACPDF() As String
        Get
            Return m_facpdf
        End Get
        Set(ByVal value As String)
            m_facpdf = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_facnro = 0
        m_facpdf = ""
        
    End Sub
    Public Sub New(ByVal facnro As Long, ByVal facpdf As String)
        m_facnro = facnro
        m_facpdf = facpdf
    End Sub
#End Region

    Public Function listarxfecha(ByVal fecha As String) As ArrayList
        Dim p As New pMovCte2
        Return p.listarxfecha(fecha)
    End Function
    Public Function buscar() As dFactur
        Dim p As New pFactur
        Return p.buscar(Me)
    End Function
End Class
