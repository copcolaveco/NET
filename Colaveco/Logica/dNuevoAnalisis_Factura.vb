Public Class dNuevoAnalisis_Factura
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_muestra As String
    Private m_analisis As Integer
#End Region

#Region "Getters y Setters"
    Public Property ID() As Long
        Get
            Return m_id
        End Get
        Set(ByVal value As Long)
            m_id = value
        End Set
    End Property
    Public Property FICHA() As Long
        Get
            Return m_ficha
        End Get
        Set(ByVal value As Long)
            m_ficha = value
        End Set
    End Property
    Public Property MUESTRA() As String
        Get
            Return m_muestra
        End Get
        Set(ByVal value As String)
            m_muestra = value
        End Set
    End Property
    Public Property ANALISIS() As Integer
        Get
            Return m_analisis
        End Get
        Set(ByVal value As Integer)
            m_analisis = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_muestra = ""
        m_analisis = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal muestra As String, ByVal analisis As Integer)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_analisis = analisis
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pNuevoAnalisis_Factura
        Return e.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pNuevoAnalisis_Factura
        Return e.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pNuevoAnalisis_Factura
        Return e.eliminar(Me, usuario)
    End Function
    Public Function vaciar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pNuevoAnalisis_Factura
        Return e.vaciar(Me, usuario)
    End Function
    Public Function buscar() As dNuevoAnalisis_Factura
        Dim e As New pNuevoAnalisis_Factura
        Return e.buscar(Me)
    End Function
    Public Function buscarrepetidas() As dNuevoAnalisis_Factura
        Dim e As New pNuevoAnalisis_Factura
        Return e.buscarrepetidas(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String

        Return m_muestra

    End Function
    Public Function listar() As ArrayList
        Dim e As New pNuevoAnalisis_Factura
        Return e.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim e As New pNuevoAnalisis_Factura
        Return e.listarfichas
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim e As New pNuevoAnalisis_Factura
        Return e.listarporid(texto)
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim e As New pNuevoAnalisis_Factura
        Return e.listarporficha(texto)
    End Function
    Public Function listarporficha2(ByVal texto As Long) As ArrayList
        Dim e As New pNuevoAnalisis_Factura
        Return e.listarporficha2(texto)
    End Function
    Public Function listarpormuestra(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim e As New pNuevoAnalisis_Factura
        Return e.listarpormuestra(ficha, muestra)
    End Function
    Public Function listardistintosanalisis(ByVal ficha As Long) As ArrayList
        Dim e As New pNuevoAnalisis_Factura
        Return e.listardistintosanalisis(ficha)
    End Function
    Public Function listarxanalisis(ByVal idficha As Long, ByVal idana As Integer) As ArrayList
        Dim e As New pNuevoAnalisis_Factura
        Return e.listarxanalisis(idficha, idana)
    End Function
End Class
