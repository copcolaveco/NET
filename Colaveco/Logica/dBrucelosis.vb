Public Class dBrucelosis
#Region "Atributos"
    Private m_id As Long
    Private m_idgrupal As Long
    Private m_columna As Integer
    Private m_fila As String
    Private m_fecha As String
    Private m_ficha As String
    Private m_muestra As String
    Private m_resultado As Integer
    Private m_operador As String
    Private m_marca As Integer

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
    Public Property IDGRUPAL() As Long
        Get
            Return m_idgrupal
        End Get
        Set(ByVal value As Long)
            m_idgrupal = value
        End Set
    End Property
    Public Property COLUMNA() As Integer
        Get
            Return m_columna
        End Get
        Set(ByVal value As Integer)
            m_columna = value
        End Set
    End Property
    Public Property FILA() As String
        Get
            Return m_fila
        End Get
        Set(ByVal value As String)
            m_fila = value
        End Set
    End Property
    Public Property FECHA() As String
        Get
            Return m_fecha
        End Get
        Set(ByVal value As String)
            m_fecha = value
        End Set
    End Property
    Public Property FICHA() As String
        Get
            Return m_ficha
        End Get
        Set(ByVal value As String)
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
    Public Property RESULTADO() As Integer
        Get
            Return m_resultado
        End Get
        Set(ByVal value As Integer)
            m_resultado = value
        End Set
    End Property

    Public Property OPERADOR() As Integer
        Get
            Return m_operador
        End Get
        Set(ByVal value As Integer)
            m_operador = value
        End Set
    End Property
    Public Property MARCA() As Integer
        Get
            Return m_marca
        End Get
        Set(ByVal value As Integer)
            m_marca = value
        End Set
    End Property




#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_idgrupal = 0
        m_columna = 0
        m_fila = ""
        m_fecha = ""
        m_ficha = ""
        m_muestra = ""
        m_resultado = 0
        m_operador = 0

    End Sub
    Public Sub New(ByVal id As Long, ByVal idgrupal As Long, ByVal columna As Integer, ByVal fila As String, _
                   ByVal fecha As String, ByVal ficha As String, ByVal muestra As String, _
                   ByVal resultado As Integer, ByVal operador As Integer, ByVal marca As Integer)
        m_id = id
        m_idgrupal = idgrupal
        m_columna = columna
        m_fila = fila
        m_fecha = fecha
        m_ficha = ficha
        m_muestra = muestra
        m_resultado = resultado
        m_operador = operador
        m_marca = marca
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pBrucelosis
        Return c.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pBrucelosis
        Return c.modificar(Me, usuario)
    End Function
    Public Function modificar2(ByVal usuario As dUsuario) As Boolean
        Dim c As New pBrucelosis
        Return c.modificar2(Me, usuario)
    End Function
    Public Function desmarcarficha() As Boolean
        Dim c As New pBrucelosis
        Return c.desmarcarficha(Me)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim c As New pBrucelosis
        Return c.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dBrucelosis
        Dim c As New pBrucelosis
        Return c.buscar(Me)
    End Function
    Public Function buscarxfichaxmuestra() As dBrucelosis
        Dim c As New pBrucelosis
        Return c.buscarxfichaxmuestra(Me)
    End Function
    Public Function buscarxficha() As dBrucelosis
        Dim c As New pBrucelosis
        Return c.buscarxficha(Me)
    End Function

#End Region

    Public Overrides Function ToString() As String
        Return m_columna & " " & m_fila & " - " & m_idgrupal & " - " & m_muestra
    End Function
    Public Function listar() As ArrayList
        Dim c As New pBrucelosis
        Return c.listar
    End Function
    Public Function listargrupos() As ArrayList
        Dim c As New pBrucelosis
        Return c.listargrupos
    End Function
    Public Function listarfichas() As ArrayList
        Dim c As New pBrucelosis
        Return c.listarfichas
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim c As New pBrucelosis
        Return c.listarporid(texto)
    End Function

    Public Function listarporsolicitud(ByVal texto As Long) As ArrayList
        Dim c As New pBrucelosis
        Return c.listarporsolicitud(texto)
    End Function
    Public Function listarporfichapos(ByVal texto As Long) As ArrayList
        Dim c As New pBrucelosis
        Return c.listarporfichapos(texto)
    End Function
    Public Function listarporfichaneg(ByVal texto As Long) As ArrayList
        Dim c As New pBrucelosis
        Return c.listarporfichaneg(texto)
    End Function

    Public Function listar1_2(ByVal texto As Long) As ArrayList
        Dim c As New pBrucelosis
        Return c.listar1_2(texto)
    End Function
    Public Function listar3_4(ByVal texto As Long) As ArrayList
        Dim c As New pBrucelosis
        Return c.listar3_4(texto)
    End Function
    Public Function listar5_6(ByVal texto As Long) As ArrayList
        Dim c As New pBrucelosis
        Return c.listar5_6(texto)
    End Function
    Public Function listar7_8(ByVal texto As Long) As ArrayList
        Dim c As New pBrucelosis
        Return c.listar7_8(texto)
    End Function
    Public Function listar9_10(ByVal texto As Long) As ArrayList
        Dim c As New pBrucelosis
        Return c.listar9_10(texto)
    End Function
    Public Function listar11_12(ByVal texto As Long) As ArrayList
        Dim c As New pBrucelosis
        Return c.listar11_12(texto)
    End Function
    Public Function marcar(ByVal idgrupal As Long, ByVal usuario As dUsuario) As Boolean
        Dim c As New pBrucelosis
        Return c.marcar(idgrupal, usuario)
    End Function
    Public Function marcarxficha(ByVal ficha As Long, ByVal usuario As dUsuario) As Boolean
        Dim c As New pBrucelosis
        Return c.marcarxficha(ficha, usuario)
    End Function
    Public Function existeResultadoPositivoPorCliente(ByVal productorId As Long) As Boolean
        Dim c As New pBrucelosis
        Return c.existeResultadoPositivoPorCliente(productorId)
    End Function

End Class
