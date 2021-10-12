Public Class dAnalisisTercerizado
#Region "Atributos"
    Private m_id As Long
    Private m_ficha As Long
    Private m_muestra As String
    Private m_tipoinforme As Integer
    Private m_analisis As Integer
    Private m_resultado As String
    Private m_metodo As String
    Private m_unidad As String
    Private m_orden As Integer
    Private m_operador As Integer
    Private m_fechaproceso As String
    Private m_laboratorio As Integer
    Private m_finalizado As Integer
    Private m_eliminado As Integer
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
    Public Property TIPOINFORME() As Integer
        Get
            Return m_tipoinforme
        End Get
        Set(ByVal value As Integer)
            m_tipoinforme = value
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
    Public Property RESULTADO() As String
        Get
            Return m_resultado
        End Get
        Set(ByVal value As String)
            m_resultado = value
        End Set
    End Property
    Public Property METODO() As String
        Get
            Return m_metodo
        End Get
        Set(ByVal value As String)
            m_metodo = value
        End Set
    End Property
    Public Property UNIDAD() As String
        Get
            Return m_unidad
        End Get
        Set(ByVal value As String)
            m_unidad = value
        End Set
    End Property
    Public Property ORDEN() As Integer
        Get
            Return m_orden
        End Get
        Set(ByVal value As Integer)
            m_orden = value
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
    Public Property FECHAPROCESO() As String
        Get
            Return m_fechaproceso
        End Get
        Set(ByVal value As String)
            m_fechaproceso = value
        End Set
    End Property
    Public Property LABORATORIO() As Integer
        Get
            Return m_laboratorio
        End Get
        Set(ByVal value As Integer)
            m_laboratorio = value
        End Set
    End Property
    Public Property FINALIZADO() As Integer
        Get
            Return m_finalizado
        End Get
        Set(ByVal value As Integer)
            m_finalizado = value
        End Set
    End Property
    Public Property ELIMINADO() As Integer
        Get
            Return m_eliminado
        End Get
        Set(ByVal value As Integer)
            m_eliminado = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_ficha = 0
        m_muestra = ""
        m_tipoinforme = 0
        m_analisis = 0
        m_resultado = ""
        m_metodo = ""
        m_unidad = ""
        m_orden = 0
        m_operador = 0
        m_fechaproceso = ""
        m_laboratorio = 0
        m_finalizado = 0
        m_eliminado = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal ficha As Long, ByVal muestra As String, ByVal tipoinforme As Integer, ByVal analisis As Integer, ByVal resultado As String, ByVal metodo As String, ByVal unidad As String, ByVal orden As Integer, ByVal operador As Integer, ByVal fechaproceso As String, ByVal laboratorio As Integer, ByVal finalizado As Integer, ByVal eliminado As Integer)
        m_id = id
        m_ficha = ficha
        m_muestra = muestra
        m_tipoinforme = tipoinforme
        m_analisis = analisis
        m_resultado = resultado
        m_metodo = metodo
        m_unidad = unidad
        m_orden = orden
        m_operador = operador
        m_fechaproceso = fechaproceso
        m_laboratorio = laboratorio
        m_finalizado = finalizado
        m_eliminado = eliminado
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.modificar(Me, usuario)
    End Function
    Public Function modificarlaboratorios(ByVal usuario As dUsuario) As Boolean
        Dim p As New pAnalisisTercerizado
        Return p.modificarlaboratorios(Me, usuario)
    End Function
    Public Function marcarfinalizado(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.marcarfinalizado(Me, usuario)
    End Function
    Public Function marcareliminado(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.marcareliminado(Me, usuario)
    End Function
    Public Function asignaroperador(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.asignaroperador(Me, usuario)
    End Function
    Public Function actualizar_resultado(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.actualizar_resultado(Me, usuario)
    End Function
    Public Function actualizar_laboratorio(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.actualizar_laboratorio(Me, usuario)
    End Function
    Public Function actualizar_metodo(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.actualizar_metodo(Me, usuario)
    End Function
    Public Function actualizar_unidad(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.actualizar_unidad(Me, usuario)
    End Function
    Public Function actualizar_fecha(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.actualizar_fecha(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim e As New pAnalisisTercerizado
        Return e.eliminar(Me, usuario)
    End Function

    Public Function buscar() As dAnalisisTercerizado
        Dim e As New pAnalisisTercerizado
        Return e.buscar(Me)
    End Function
    Public Function buscarxficha() As dAnalisisTercerizado
        Dim e As New pAnalisisTercerizado
        Return e.buscarxficha(Me)
    End Function
    Public Function buscarrepetidas() As dAnalisisTercerizado
        Dim e As New pAnalisisTercerizado
        Return e.buscarrepetidas(Me)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_muestra
    End Function
    Public Function listar() As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listar
    End Function
    Public Function listarfichas() As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarfichas
    End Function
    Public Function listarfichasnuevas(ByVal tipoinf As Integer) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarfichasnuevas(tipoinf)
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarporid(texto)
    End Function
    Public Function listarporficha(ByVal texto As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarporficha(texto)
    End Function
    Public Function listarporfichamuestra(ByVal texto As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarporfichamuestra(texto)
    End Function
    Public Function listarporfichamuestra2(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarporfichamuestra2(ficha, muestra)
    End Function
    Public Function listarporficha2(ByVal texto As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarporficha2(texto)
    End Function
    Public Function listarporficha3(ByVal texto As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarporficha3(texto)
    End Function
    Public Function listarporficha4(ByVal texto As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarporficha4(texto)
    End Function
    Public Function listarporficha5(ByVal texto As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarporficha5(texto)
    End Function
    Public Function listarporficha6(ByVal texto As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarporficha6(texto)
    End Function
    Public Function listarpormuestra(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarpormuestra(ficha, muestra)
    End Function
    Public Function listardistintosanalisis(ByVal ficha As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listardistintosanalisis(ficha)
    End Function
    Public Function listaranalisisnoeliminados(ByVal ficha As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listaranalisisnoeliminados(ficha)
    End Function
    Public Function listarlaboratorios(ByVal ficha As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarlaboratorios(ficha)
    End Function
    Public Function listarmetodos(ByVal ficha As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarmetodos(ficha)
    End Function
    Public Function listardistintosanalisisvacios(ByVal ficha As Long) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listardistintosanalisisvacios(ficha)
    End Function
    Public Function listarxanalisis(ByVal id As Integer) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarxanalisis(id)
    End Function
    Public Function listarxfichaxanalisis(ByVal ficha As Long, ByVal id As Integer) As ArrayList
        Dim e As New pAnalisisTercerizado
        Return e.listarxfichaxanalisis(ficha, id)
    End Function
End Class
