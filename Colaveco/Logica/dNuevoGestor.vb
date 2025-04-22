Public Class dNuevoGestor

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
    Private m_solicitudestadoid As Integer
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
    Public Property SOLICITUDESTADOID() As Integer
        Get
            Return m_solicitudestadoid
        End Get
        Set(ByVal value As Integer)
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
    Public Sub New(ByVal id As Long, ByVal fechaingreso As String, ByVal idproductor As Long, ByVal idtipoinforme As Integer, ByVal idsubinforme As Integer, ByVal idtipoficha As Integer, ByVal observaciones As String, ByVal nmuestras As Integer, ByVal idmuestra As Integer, ByVal idtecnico As Long, ByVal sinsolicitud As Integer, ByVal sinconservante As Integer, ByVal temperatura As Double, ByVal derramadas As Integer, ByVal desvioautorizado As Integer, ByVal idfactura As Long, ByVal web As Integer, ByVal personal As Integer, ByVal email As Integer, ByVal fechaenvio As String, ByVal marca As Integer, ByVal eliminado As Integer, ByVal tambo As Integer, ByVal pago As Integer, ByVal importe As Double, ByVal kmts As Integer, ByVal obsinternas As String, ByVal codigo As String, ByVal fechaproceso As String, ByVal muestreo As Integer, ByVal logo As Integer, ByVal interpretacion As String, ByVal fechamuestreo As String, ByVal operador As Integer, ByVal solicitudestadoid As Integer)
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
    Public Function guardarNuevoGestor(ByVal usuario As dUsuario) As Boolean
        Dim s As New NuevoGestor
        Return s.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim s As New NuevoGestor
        Return s.modificarEstado(Me, usuario)
    End Function

    Public Function modificarFechaEnvio(ByVal usuario As dUsuario) As Boolean
        Dim s As New NuevoGestor
        Return s.modificarfechaEnvio(Me, usuario)
    End Function
    
#End Region
    Public Overrides Function ToString() As String
        Dim pr As New dCliente
        Dim ti As New dTipoInforme
        pr.ID = m_idproductor
        pr = pr.buscar
        ti.ID = m_idtipoinforme
        ti = ti.buscar
        Return m_id & Chr(9) & m_fechaingreso & Chr(9) & m_nmuestras & Chr(9) & ti.NOMBRE & Chr(9) & Chr(9) & pr.NOMBRE ' & m_fechaingreso & Chr(9) & pr.NOMBRE
    End Function
   
End Class
