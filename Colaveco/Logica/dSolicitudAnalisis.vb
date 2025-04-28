Public Class dSolicitudAnalisis
#Region "Atributos"
    Private m_id As Long
    Private m_fechaingreso As String
    Private m_idproductor As Long
    Private m_idtipoinforme As Integer
    Private m_idsubinforme As Integer
    Private m_idtipoficha As Integer
    Private m_observaciones As String
    Private m_nmuestras As Integer
    Private m_idmuestra As Integer
    Private m_idtecnico As Long
    Private m_sinsolicitud As Integer
    Private m_sinconservante As Integer
    Private m_temperatura As Double
    Private m_derramadas As Integer
    Private m_desvioautorizado As Integer
    Private m_idfactura As Long
    Private m_web As Integer
    Private m_personal As Integer
    Private m_email As Integer
    Private m_fechaenvio As String
    Private m_marca As Integer
    Private m_eliminado As Integer
    Private m_tambo As Integer
    Private m_pago As Integer
    Private m_importe As Double
    Private m_kmts As Integer
    Private m_obsinternas As String
    Private m_codigo As String
    Private m_fechaproceso As String
    Private m_muestreo As Integer
    Private m_logo As Integer
    Private m_interpretacion As String
    Private m_fechamuestreo As String
    Private m_operador As Integer
    Private m_solicitudestadoid As Integer?
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
    Public Property FECHAINGRESO() As String
        Get
            Return m_fechaingreso
        End Get
        Set(ByVal value As String)
            m_fechaingreso = value
        End Set
    End Property
    Public Property IDPRODUCTOR() As Long
        Get
            Return m_idproductor
        End Get
        Set(ByVal value As Long)
            m_idproductor = value
        End Set
    End Property
    Public Property IDTIPOINFORME() As Integer
        Get
            Return m_idtipoinforme
        End Get
        Set(ByVal value As Integer)
            m_idtipoinforme = value
        End Set
    End Property
    Public Property IDSUBINFORME() As Integer
        Get
            Return m_idsubinforme
        End Get
        Set(ByVal value As Integer)
            m_idsubinforme = value
        End Set
    End Property
    Public Property IDTIPOFICHA() As Integer
        Get
            Return m_idtipoficha
        End Get
        Set(ByVal value As Integer)
            m_idtipoficha = value
        End Set
    End Property
    Public Property OBSERVACIONES() As String
        Get
            Return m_observaciones
        End Get
        Set(ByVal value As String)
            m_observaciones = value
        End Set
    End Property
    Public Property NMUESTRAS() As Integer
        Get
            Return m_nmuestras
        End Get
        Set(ByVal value As Integer)
            m_nmuestras = value
        End Set
    End Property
    Public Property IDMUESTRA() As Integer
        Get
            Return m_idmuestra
        End Get
        Set(ByVal value As Integer)
            m_idmuestra = value
        End Set
    End Property
    Public Property IDTECNICO() As Long
        Get
            Return m_idtecnico
        End Get
        Set(ByVal value As Long)
            m_idtecnico = value
        End Set
    End Property
    Public Property SINCOLICITUD() As Integer
        Get
            Return m_sinsolicitud
        End Get
        Set(ByVal value As Integer)
            m_sinsolicitud = value
        End Set
    End Property
    Public Property SINCONSERVANTE() As Integer
        Get
            Return m_sinconservante
        End Get
        Set(ByVal value As Integer)
            m_sinconservante = value
        End Set
    End Property
    Public Property TEMPERATURA() As Double
        Get
            Return m_temperatura
        End Get
        Set(ByVal value As Double)
            m_temperatura = value
        End Set
    End Property
    Public Property DERRAMADAS() As Integer
        Get
            Return m_derramadas
        End Get
        Set(ByVal value As Integer)
            m_derramadas = value
        End Set
    End Property
    Public Property DESVIOAUTORIZADO() As Integer
        Get
            Return m_desvioautorizado
        End Get
        Set(ByVal value As Integer)
            m_desvioautorizado = value
        End Set
    End Property
    Public Property IDFACTURA() As Long
        Get
            Return m_idfactura
        End Get
        Set(ByVal value As Long)
            m_idfactura = value
        End Set
    End Property
    Public Property WEB() As Integer
        Get
            Return m_web
        End Get
        Set(ByVal value As Integer)
            m_web = value
        End Set
    End Property
    Public Property PERSONAL() As Integer
        Get
            Return m_personal
        End Get
        Set(ByVal value As Integer)
            m_personal = value
        End Set
    End Property
    Public Property EMAIL() As Integer
        Get
            Return m_email
        End Get
        Set(ByVal value As Integer)
            m_email = value
        End Set
    End Property
    Public Property FECHAENVIO() As String
        Get
            Return m_fechaenvio
        End Get
        Set(ByVal value As String)
            m_fechaenvio = value
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
    Public Property ELIMINADO() As Integer
        Get
            Return m_eliminado
        End Get
        Set(ByVal value As Integer)
            m_eliminado = value
        End Set
    End Property
    Public Property TAMBO() As Integer
        Get
            Return m_tambo
        End Get
        Set(ByVal value As Integer)
            m_tambo = value
        End Set
    End Property
    Public Property PAGO() As Integer
        Get
            Return m_pago
        End Get
        Set(ByVal value As Integer)
            m_pago = value
        End Set
    End Property
    Public Property IMPORTE() As Double
        Get
            Return m_importe
        End Get
        Set(ByVal value As Double)
            m_importe = value
        End Set
    End Property
    Public Property KMTS() As Integer
        Get
            Return m_kmts
        End Get
        Set(ByVal value As Integer)
            m_kmts = value
        End Set
    End Property
    Public Property OBSINTERNAS() As String
        Get
            Return m_obsinternas
        End Get
        Set(ByVal value As String)
            m_obsinternas = value
        End Set
    End Property
    Public Property CODIGO() As String
        Get
            Return m_codigo
        End Get
        Set(ByVal value As String)
            m_codigo = value
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
    Public Property MUESTREO() As Integer
        Get
            Return m_muestreo
        End Get
        Set(ByVal value As Integer)
            m_muestreo = value
        End Set
    End Property
    Public Property LOGO() As Integer
        Get
            Return m_logo
        End Get
        Set(ByVal value As Integer)
            m_logo = value
        End Set
    End Property
    Public Property INTERPRETACION() As String
        Get
            Return m_interpretacion
        End Get
        Set(ByVal value As String)
            m_interpretacion = value
        End Set
    End Property
    Public Property FECHAMUESTREO() As String
        Get
            Return m_fechamuestreo
        End Get
        Set(ByVal value As String)
            m_fechamuestreo = value
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
    Public Property SOLICITUDESTADOID() As Integer?
        Get
            Return m_solicitudestadoid
        End Get
        Set(ByVal value As Integer?)
            m_solicitudestadoid = value
        End Set
    End Property


#End Region
#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_fechaingreso = ""
        m_idproductor = 0
        m_idtipoinforme = 0
        m_idsubinforme = 0
        m_idtipoficha = 0
        m_observaciones = ""
        m_nmuestras = 0
        m_idmuestra = 0
        m_idtecnico = 0
        m_sinsolicitud = 0
        m_sinconservante = 0
        m_temperatura = 0
        m_derramadas = 0
        m_desvioautorizado = 0
        m_idfactura = 0
        m_web = 0
        m_personal = 0
        m_email = 0
        m_fechaenvio = ""
        m_marca = 0
        m_eliminado = 0
        m_tambo = 0
        m_pago = 0
        m_importe = 0
        m_kmts = 0
        m_obsinternas = ""
        m_codigo = ""
        m_fechaproceso = ""
        m_muestreo = 0
        m_logo = 0
        m_interpretacion = ""
        m_fechamuestreo = ""
        m_operador = 0
        m_solicitudestadoid = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal fechaingreso As String, ByVal idproductor As Long, ByVal idtipoinforme As Integer, ByVal idsubinforme As Integer, ByVal idtipoficha As Integer, ByVal observaciones As String, ByVal nmuestras As Integer, ByVal idmuestra As Integer, ByVal idtecnico As Long, ByVal sinsolicitud As Integer, ByVal sinconservante As Integer, ByVal temperatura As Double, ByVal derramadas As Integer, ByVal desvioautorizado As Integer, ByVal idfactura As Long, ByVal web As Integer, ByVal personal As Integer, ByVal email As Integer, ByVal fechaenvio As String, ByVal marca As Integer, ByVal eliminado As Integer, ByVal tambo As Integer, ByVal pago As Integer, ByVal importe As Double, ByVal kmts As Integer, ByVal obsinternas As String, ByVal codigo As String, ByVal fechaproceso As String, ByVal muestreo As Integer, ByVal logo As Integer, ByVal interpretacion As String, ByVal fechamuestreo As String, ByVal operador As Integer, ByVal solicitudestadoid As Integer?)
        m_id = id
        m_fechaingreso = fechaingreso
        m_idproductor = idproductor
        m_idtipoinforme = idtipoinforme
        m_idsubinforme = idsubinforme
        m_idtipoficha = idtipoficha
        m_observaciones = observaciones
        m_nmuestras = nmuestras
        m_idmuestra = idmuestra
        m_idtecnico = idtecnico
        m_sinsolicitud = sinsolicitud
        m_sinconservante = sinconservante
        m_temperatura = temperatura
        m_derramadas = derramadas
        m_desvioautorizado = desvioautorizado
        m_idfactura = idfactura
        m_web = web
        m_personal = personal
        m_email = email
        m_fechaingreso = fechaingreso
        m_marca = marca
        m_eliminado = eliminado
        m_tambo = tambo
        m_pago = pago
        m_importe = importe
        m_kmts = kmts
        m_obsinternas = obsinternas
        m_codigo = codigo
        m_fechaproceso = fechaproceso
        m_muestreo = muestreo
        m_logo = logo
        m_interpretacion = interpretacion
        m_fechamuestreo = fechamuestreo
        m_operador = operador
        m_solicitudestadoid = solicitudestadoid
    End Sub
#End Region
#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.modificar(Me, usuario)
    End Function
    Public Function modificartambo(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.modificartambo(Me, usuario)
    End Function
    Public Function modificarobservaciones(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.modificarobservaciones(Me, usuario)
    End Function
    Public Function modificarinterpretacion(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.modificarinterpretacion(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.eliminar(Me, usuario)
    End Function
    Public Function eliminar2(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.eliminar2(Me, usuario)
    End Function
    Public Function desmarcar(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.desmarcar(Me, usuario)
    End Function
    Public Function desmarcarpago(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.desmarcarpago(Me, usuario)
    End Function
    Public Function marcar(ByVal usuario As dUsuario, ByRef fechaEnvio As String) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.marcar(Me, usuario, fechaEnvio)
    End Function
    Public Function marcarlogo(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.marcarlogo(Me, usuario)
    End Function
    Public Function marcarpago(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.marcarpago(Me, usuario)
    End Function
    Public Function marcarpago2(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.marcarpago2(Me, usuario)
    End Function
    Public Function marcar2() As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.marcar2(Me)
    End Function
    Public Function marcar3(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.marcar3(Me, usuario)
    End Function
    Public Function marcareliminado(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.marcareliminado(Me, usuario)
    End Function
    Public Function actualizar_cantidad_muestras(ByVal usuario As dUsuario) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.actualizar_cantidad_muestras(Me, usuario)
    End Function
    Public Function actualizarfechaenvio(ByVal fecha As String) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.actualizarfechaenvio(Me, fecha)
    End Function
    Public Function actualizarfechaenvio2(ByVal fecha As String) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.actualizarfechaenvio(Me, fecha)
    End Function
    Public Function actualizarfechaproceso(ByVal fecha As String) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.actualizarfechaproceso(Me, fecha)
    End Function
    Public Function actualizarimporte(ByVal importe As Double) As Boolean
        Dim s As New pSolicitudAnalisis
        Return s.actualizarimporte(Me, importe)
    End Function
    Public Function buscar() As dSolicitudAnalisis
        Dim s As New pSolicitudAnalisis
        Return s.buscar(Me)
    End Function
    Public Function verificarExistenciaSolicitud(ByVal id As Long) As Boolean
        ' Llamar a la función existeSolicitudAnalisis para verificar la existencia del ID
        Dim s As New pSolicitudAnalisis
        Return s.existeSolicitudAnalisis(id)
    End Function
    Public Function buscarultimoid() As dSolicitudAnalisis
        Dim s As New pSolicitudAnalisis
        Return s.buscarultimoid(Me)
    End Function
#End Region
    Public Overrides Function ToString() As String
        Dim pr As New dCliente
        Dim ti As New dTipoInforme
        pr.ID = m_idproductor
        pr = pr.buscar
        ti.ID = m_idtipoinforme
        ti = ti.buscar
        Return m_id & Chr(9) & m_fechaingreso & Chr(9) & m_nmuestras & Chr(9) & ti.NOMBRE & Chr(9) & pr.NOMBRE ' & m_fechaingreso & Chr(9) & pr.NOMBRE
    End Function
    Public Function listar() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listar
    End Function
    Public Function listarultimos6meses(ByVal f As Long) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarultimos6meses(f)
    End Function
    Public Function listarpendientes() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarpendientes
    End Function
    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarporid(texto)
    End Function
    Public Function listarxtipo(ByVal texto As Integer) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarxtipo(texto)
    End Function
    Public Function listarxtipoxclientexfecha(ByVal tipo As Integer, ByVal cli As Long, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarxtipoxclientexfecha(tipo, cli, desde, hasta)
    End Function
    Public Function listarultimoid() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarultimoid
    End Function
    Public Function listarporproductor(ByVal texto As Long, ByVal fecd As String, ByVal fech As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarporproductor(texto, fecd, fech)
    End Function
    Public Function listarportipoinforme(ByVal tipoinforme As Long, ByVal fecd As String, ByVal fech As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarportipoinforme(tipoinforme, fecd, fech)
    End Function
    Public Function listarporproductor2(ByVal texto As Long) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarporproductor2(texto)
    End Function
    Public Function listarporproductor3(ByVal texto As Long) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarporproductor3(texto)
    End Function
    Public Function listarporproductorultimas3(ByVal texto As Long, ByVal ficha As Long) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarporproductorultimas3(texto, ficha)
    End Function
    Public Function listarxproductorsinenviar(ByVal texto As Long) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarxproductorsinenviar(texto)
    End Function
    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarporfecha(fechadesde, fechahasta)
    End Function
    Public Function listarfichas(ByVal fichadesde As Long, ByVal fichahasta As Long) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichas(fichadesde, fichahasta)
    End Function
    Public Function listarxfechaxproductor(ByVal fechadesde As String, ByVal fechahasta As String, ByVal idproductor As Long) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarxfechaxproductor(fechadesde, fechahasta, idproductor)
    End Function
    Public Function listarporfecha2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarporfecha2(fechadesde, fechahasta)
    End Function
    Public Function listarxfechaxempresa(ByVal desde As String, ByVal hasta As String, ByVal idempresa As Long, ByVal idTipoInforme As Integer) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarxfechaxempresa(desde, hasta, idempresa, idTipoInforme)
    End Function
    Public Function listarporfechacalidad(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarporfechacalidad(fechadesde, fechahasta)
    End Function
    Public Function listarporfechacalidadempresa(ByVal fechadesde As String, ByVal fechahasta As String, ByVal idempresa As Long) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarporfechacalidadempresa(fechadesde, fechahasta, idempresa)
    End Function
    Public Function listarporfechaxcant(ByVal fechadesde As String, ByVal fechahasta As String, ByVal contador As Integer) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarporfechaxcant(fechadesde, fechahasta, contador)
    End Function
    Public Function listarfichasagua() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichasagua
    End Function
    Public Function listarfichassubproductos() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichassubproductos
    End Function
    Public Function listarfichasantibiograma() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichasantibiograma
    End Function
    Public Function listarfichascalidad() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichascalidad
    End Function
    Public Function listarfichascontrol() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichascontrol
    End Function
    Public Function listarfichasPAL() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichasPAL
    End Function
    Public Function listarfichasLeucosis() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichasLeucosis
    End Function
    Public Function listarfichasBrucelosis() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichasBrucelosis
    End Function
    Public Function listarfichasnutricion() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichasnutricion
    End Function
    Public Function listarfichassuelos() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichassuelos
    End Function
    Public Function listarfichasRosaBengala() As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.listarfichasRosaBengala
    End Function
    Public Function controlnutricion1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlnutricion1(fechadesde, fechahasta)
    End Function
    Public Function controlnutricion2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlnutricion2(fechadesde, fechahasta)
    End Function
    Public Function controlsuelos1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlsuelos1(fechadesde, fechahasta)
    End Function
    Public Function controlsuelos2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlsuelos2(fechadesde, fechahasta)
    End Function
    Public Function controlbrucelosis1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlbrucelosis1(fechadesde, fechahasta)
    End Function
    Public Function controlbrucelosis2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlbrucelosis2(fechadesde, fechahasta)
    End Function
    Public Function controlparasitologia1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlparasitologia1(fechadesde, fechahasta)
    End Function
    Public Function controlparasitologia2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlparasitologia2(fechadesde, fechahasta)
    End Function
    Public Function controlclechero1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlclechero1(fechadesde, fechahasta)
    End Function
    Public Function controlclechero2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlclechero2(fechadesde, fechahasta)
    End Function
    Public Function controlclechero5(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlclechero5(fechadesde, fechahasta)
    End Function
    Public Function controlcalidad1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlcalidad1(fechadesde, fechahasta)
    End Function
    Public Function controlcalidad2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlcalidad2(fechadesde, fechahasta)
    End Function
    Public Function controlcalidad5(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlcalidad5(fechadesde, fechahasta)
    End Function
    Public Function controlcalidadvarios(ByVal fechadesde As String, ByVal fechahasta As String, ByVal faltan As Integer) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlcalidadvarios(fechadesde, fechahasta, faltan)
    End Function
    Public Function controlagua1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlagua1(fechadesde, fechahasta)
    End Function
    Public Function controlagua2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlagua2(fechadesde, fechahasta)
    End Function
    Public Function controlagua5(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlagua5(fechadesde, fechahasta)
    End Function
    Public Function controlsubproductos1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlsubproductos1(fechadesde, fechahasta)
    End Function
    Public Function controlsubproductos2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlsubproductos2(fechadesde, fechahasta)
    End Function
    Public Function controlsubproductos5(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlsubproductos5(fechadesde, fechahasta)
    End Function
    Public Function controlserologia1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlserologia1(fechadesde, fechahasta)
    End Function
    Public Function controlserologia2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlserologia2(fechadesde, fechahasta)
    End Function
    Public Function controlpal1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlpal1(fechadesde, fechahasta)
    End Function
    Public Function controlpal2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlpal2(fechadesde, fechahasta)
    End Function
    Public Function controltoxicologia1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controltoxicologia1(fechadesde, fechahasta)
    End Function
    Public Function controltoxicologia2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controltoxicologia2(fechadesde, fechahasta)
    End Function
    Public Function controlbacteriologia1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlbacteriologia1(fechadesde, fechahasta)
    End Function
    Public Function controlbacteriologia2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.controlbacteriologia2(fechadesde, fechahasta)
    End Function
    '*** LISTADO DE SOLICITUDES POR TIPO Y SUBTIPO DE INFORME **************************************************************************************
    Public Function lista_sol_clechero(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_clechero(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_controlurea(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_controlurea(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_completo(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_completo(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_fqcompleto(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_fqcompleto(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_bacteriologico(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_bacteriologico(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_fqcloro(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_fqcloro(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_fqcondph(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_fqcondph(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_heterotroficos(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_heterotroficos(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_antibiograma(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_antibiograma(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_bactanque(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_bactanque(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_aislamiento(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_aislamiento(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_pal(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_pal(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_brucelosis_leche(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_brucelosis_leche(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_parasitologia(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_parasitologia(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_paquete1(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_paquete1(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_paquete2(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_paquete2(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_paquete3(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_paquete3(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_fq(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_fq(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_microbiologia(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_microbiologia(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_otros(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_otros(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_microfq(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_microfq(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_serologia(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_serologia(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_brucelosis(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_brucelosis(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_leucosis(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_leucosis(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_anaclinicos(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_anaclinicos(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_patologia(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_patologia(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_toxicologia(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_toxicologia(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_patologiaotros(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_patologiaotros(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_calidad(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_calidad(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_calidad_esporulados(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_calidad_esporulados(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_todo(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_todo(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_delvoycrios(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_delvoycrios(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_composicion(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_composicion(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_enterobacterias(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_enterobacterias(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_lactometros(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_lactometros(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_chequeo(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_chequeo(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_nutricion(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_nutricion(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_suelos(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_suelos(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_pradera(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_pradera(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_granos(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_granos(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_raciones(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_raciones(fechadesde, fechahasta)
    End Function
    Public Function lista_sol_semen(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim s As New pSolicitudAnalisis
        Return s.lista_sol_semen(fechadesde, fechahasta)
    End Function
End Class
