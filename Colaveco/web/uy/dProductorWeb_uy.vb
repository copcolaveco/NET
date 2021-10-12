Public Class dProductorWeb_uy
#Region "Atributos"
    Private m_id As Long
    Private m_usuario As String
    Private m_nombre As String
    Private m_password As String
    Private m_tipo_usuario_id As Integer
    Private m_razon_social As String
    Private m_direccion As String
    Private m_telefono_1 As String
    Private m_telefono_2 As String
    Private m_telefono_3 As String
    Private m_celular_1 As String
    Private m_celular_2 As String
    Private m_celular_3 As String
    Private m_email_1 As String
    Private m_email_2 As String
    Private m_email_3 As String
    Private m_enviar_email As String
    Private m_enviar_sms As String
    Private m_rut As String
    Private m_dicose As String
    Private m_saldo_pesos As Double
    Private m_saldo_dolares As Double
    Private m_ver_control_lechero As Integer
    Private m_ver_agua As Integer
    Private m_ver_pal As Integer
    Private m_ver_serologia As Integer
    Private m_ver_antibiograma As Integer
    Private m_ver_parasitologia As Integer
    Private m_ver_productos_subproductos As Integer
    Private m_ver_patologia As Integer
    Private m_ver_calidad_de_leche As Integer
    Private m_tecnico_1 As Long
    Private m_fecha_tecnico As String
    Private m_id_usuario_asigna_tecnico As Long
    Private m_tecnico_2 As Long
    Private m_tecnico_3 As Long
    Private m_tecnico_4 As Long
    Private m_codigofigaro As String
    Private m_enviar_informe_por_mail As Integer
    Private m_path_estado_de_cuenta As String
    Private m_fecha_modificacion As String

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
    Public Property USUARIO() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal value As String)
            m_usuario = value
        End Set
    End Property
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property PASSWORD() As String
        Get
            Return m_password
        End Get
        Set(ByVal value As String)
            m_password = value
        End Set
    End Property
    Public Property TIPO_USUARIO_ID() As Integer
        Get
            Return m_tipo_usuario_id
        End Get
        Set(ByVal value As Integer)
            m_tipo_usuario_id = value
        End Set
    End Property
    Public Property RAZON_SOCIAL() As String
        Get
            Return m_razon_social
        End Get
        Set(ByVal value As String)
            m_razon_social = value
        End Set
    End Property
    Public Property DIRECCION() As String
        Get
            Return m_direccion
        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property
    Public Property TELEFONO_1() As String
        Get
            Return m_telefono_1
        End Get
        Set(ByVal value As String)
            m_telefono_1 = value
        End Set
    End Property
    Public Property TELEFONO_2() As String
        Get
            Return m_telefono_2
        End Get
        Set(ByVal value As String)
            m_telefono_2 = value
        End Set
    End Property
    Public Property TELEFONO_3() As String
        Get
            Return m_telefono_3
        End Get
        Set(ByVal value As String)
            m_telefono_3 = value
        End Set
    End Property
    Public Property CELULAR_1() As String
        Get
            Return m_celular_1
        End Get
        Set(ByVal value As String)
            m_celular_1 = value
        End Set
    End Property
    Public Property CELULAR_2() As String
        Get
            Return m_celular_2
        End Get
        Set(ByVal value As String)
            m_celular_2 = value
        End Set
    End Property
    Public Property CELULAR_3() As String
        Get
            Return m_celular_3
        End Get
        Set(ByVal value As String)
            m_celular_3 = value
        End Set
    End Property
    Public Property EMAIL_1() As String
        Get
            Return m_email_1
        End Get
        Set(ByVal value As String)
            m_email_1 = value
        End Set
    End Property
    Public Property EMAIL_2() As String
        Get
            Return m_email_2
        End Get
        Set(ByVal value As String)
            m_email_2 = value
        End Set
    End Property
    Public Property EMAIL_3() As String
        Get
            Return m_email_3
        End Get
        Set(ByVal value As String)
            m_email_3 = value
        End Set
    End Property
    Public Property ENVIAR_EMAIL() As String
        Get
            Return m_enviar_email
        End Get
        Set(ByVal value As String)
            m_enviar_email = value
        End Set
    End Property
    Public Property ENVIAR_SMS() As String
        Get
            Return m_enviar_sms
        End Get
        Set(ByVal value As String)
            m_enviar_sms = value
        End Set
    End Property
    Public Property RUT() As String
        Get
            Return m_rut
        End Get
        Set(ByVal value As String)
            m_rut = value
        End Set
    End Property
    Public Property DICOSE() As String
        Get
            Return m_dicose
        End Get
        Set(ByVal value As String)
            m_dicose = value
        End Set
    End Property
    Public Property SALDO_PESOS() As Double
        Get
            Return m_saldo_pesos
        End Get
        Set(ByVal value As Double)
            m_saldo_pesos = value
        End Set
    End Property
    Public Property SALDO_DOLARES() As Double
        Get
            Return m_saldo_dolares
        End Get
        Set(ByVal value As Double)
            m_saldo_dolares = value
        End Set
    End Property
    Public Property VER_CONTROL_LECHERO() As Integer
        Get
            Return m_ver_control_lechero
        End Get
        Set(ByVal value As Integer)
            m_ver_control_lechero = value
        End Set
    End Property
    Public Property VER_AGUA() As Integer
        Get
            Return m_ver_agua
        End Get
        Set(ByVal value As Integer)
            m_ver_agua = value
        End Set
    End Property
    Public Property VER_PAL() As Integer
        Get
            Return m_ver_pal
        End Get
        Set(ByVal value As Integer)
            m_ver_pal = value
        End Set
    End Property
    Public Property VER_SEROLOGIA() As Integer
        Get
            Return m_ver_serologia
        End Get
        Set(ByVal value As Integer)
            m_ver_serologia = value
        End Set
    End Property
    Public Property VER_ANTIBIOGRAMA() As Integer
        Get
            Return m_ver_antibiograma
        End Get
        Set(ByVal value As Integer)
            m_ver_antibiograma = value
        End Set
    End Property
    Public Property VER_PARASITOLOGIA() As Integer
        Get
            Return m_ver_parasitologia
        End Get
        Set(ByVal value As Integer)
            m_ver_parasitologia = value
        End Set
    End Property
    Public Property VER_PRODUCTOS_SUBPRODUCTOS() As Integer
        Get
            Return m_ver_productos_subproductos
        End Get
        Set(ByVal value As Integer)
            m_ver_productos_subproductos = value
        End Set
    End Property
    Public Property VER_PATOLOGIA() As Integer
        Get
            Return m_ver_patologia
        End Get
        Set(ByVal value As Integer)
            m_ver_patologia = value
        End Set
    End Property
    Public Property VER_CALIDAD_DE_LECHE() As Integer
        Get
            Return m_ver_calidad_de_leche
        End Get
        Set(ByVal value As Integer)
            m_ver_calidad_de_leche = value
        End Set
    End Property
    Public Property TECNICO_1() As Long
        Get
            Return m_tecnico_1
        End Get
        Set(ByVal value As Long)
            m_tecnico_1 = value
        End Set
    End Property
    Public Property FECHA_TECNICO() As String
        Get
            Return m_fecha_tecnico
        End Get
        Set(ByVal value As String)
            m_fecha_tecnico = value
        End Set
    End Property
    Public Property ID_USUARIO_ASIGNA_TECNICO() As Long
        Get
            Return m_id_usuario_asigna_tecnico
        End Get
        Set(ByVal value As Long)
            m_id_usuario_asigna_tecnico = value
        End Set
    End Property
    Public Property TECNICO_2() As Long
        Get
            Return m_tecnico_2
        End Get
        Set(ByVal value As Long)
            m_tecnico_2 = value
        End Set
    End Property
    Public Property TECNICO_3() As Long
        Get
            Return m_tecnico_3
        End Get
        Set(ByVal value As Long)
            m_tecnico_3 = value
        End Set
    End Property
    Public Property TECNICO_4() As Long
        Get
            Return m_tecnico_4
        End Get
        Set(ByVal value As Long)
            m_tecnico_4 = value
        End Set
    End Property
    Public Property CODIGOFIGARO() As String
        Get
            Return m_codigofigaro
        End Get
        Set(ByVal value As String)
            m_codigofigaro = value
        End Set
    End Property
    Public Property ENVIAR_INFORME_POR_MAIL() As Integer
        Get
            Return m_enviar_informe_por_mail
        End Get
        Set(ByVal value As Integer)
            m_enviar_informe_por_mail = value
        End Set
    End Property
    Public Property PATH_ESTADO_DE_CUENTA() As String
        Get
            Return m_path_estado_de_cuenta
        End Get
        Set(ByVal value As String)
            m_path_estado_de_cuenta = value
        End Set
    End Property
    Public Property FECHA_MODIFICACION() As String
        Get
            Return m_fecha_modificacion
        End Get
        Set(ByVal value As String)
            m_fecha_modificacion = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_usuario = ""
        m_nombre = ""
        m_password = ""
        m_tipo_usuario_id = 0
        m_razon_social = ""
        m_direccion = ""
        m_telefono_1 = ""
        m_telefono_2 = ""
        m_telefono_3 = ""
        m_celular_1 = ""
        m_celular_2 = ""
        m_celular_3 = ""
        m_email_1 = ""
        m_email_2 = ""
        m_email_3 = ""
        m_enviar_email = ""
        m_enviar_sms = ""
        m_rut = ""
        m_dicose = ""
        m_saldo_pesos = 0
        m_saldo_dolares = 0
        m_ver_control_lechero = 0
        m_ver_agua = 0
        m_ver_pal = 0
        m_ver_serologia = 0
        m_ver_antibiograma = 0
        m_ver_parasitologia = 0
        m_ver_productos_subproductos = 0
        m_ver_patologia = 0
        m_ver_calidad_de_leche = 0
        m_tecnico_1 = 0
        m_fecha_tecnico = ""
        m_id_usuario_asigna_tecnico = 0
        m_tecnico_2 = 0
        m_tecnico_3 = 0
        m_tecnico_4 = 0
        m_codigofigaro = ""
        m_enviar_informe_por_mail = 0
        m_path_estado_de_cuenta = ""
        m_fecha_modificacion = ""

    End Sub
    Public Sub New(ByVal id As Long, ByVal usuario As String, ByVal nombre As String, ByVal password As String, _
                   ByVal tipo_usuario_id As Integer, ByVal razon_social As String, ByVal direccion As String, _
                   ByVal telefono_1 As String, ByVal telefono_2 As String, ByVal telefono_3 As String, ByVal celular_1 As String, _
                   ByVal celular_2 As String, ByVal celular_3 As String, ByVal email_1 As String, ByVal email_2 As String, _
                   ByVal email_3 As String, ByVal enviar_email As String, ByVal enviar_sms As String, ByVal rut As String, _
                   ByVal dicose As String, ByVal saldo_pesos As Double, ByVal saldo_dolares As Double, ByVal ver_control_lechero As Integer, _
                   ByVal ver_agua As Integer, ByVal ver_pal As Integer, ByVal ver_serologia As Integer, ByVal ver_antibiograma As Integer, _
                   ByVal ver_parasitologia As Integer, ByVal ver_productos_subproductos As Integer, ByVal ver_patologia As Integer, _
                   ByVal ver_calidad_de_leche As Integer, ByVal tecnico_1 As Long, ByVal fecha_tecnico As String, _
                   ByVal id_usuario_asigna_tecnico As Long, ByVal tecnico_2 As Long, ByVal tecnico_3 As Long, ByVal tecnico_4 As Long, _
                   ByVal codigofigaro As String, ByVal enviar_informe_por_email As Integer, ByVal path_estado_de_cuenta As String, _
                   ByVal fecha_modificacion As String)
        m_id = id
        m_usuario = usuario
        m_nombre = nombre
        m_password = password
        m_tipo_usuario_id = tipo_usuario_id
        m_razon_social = razon_social
        m_direccion = direccion
        m_telefono_1 = telefono_1
        m_telefono_2 = telefono_2
        m_telefono_3 = telefono_3
        m_celular_1 = celular_1
        m_celular_2 = celular_2
        m_celular_3 = celular_3
        m_email_1 = email_1
        m_email_2 = email_2
        m_email_3 = email_3
        m_enviar_email = enviar_email
        m_enviar_sms = enviar_sms
        m_rut = rut
        m_dicose = dicose
        m_saldo_pesos = saldo_pesos
        m_saldo_dolares = saldo_dolares
        m_ver_control_lechero = ver_control_lechero
        m_ver_agua = ver_agua
        m_ver_pal = ver_pal
        m_ver_serologia = ver_serologia
        m_ver_antibiograma = ver_antibiograma
        m_ver_parasitologia = ver_parasitologia
        m_ver_productos_subproductos = ver_productos_subproductos
        m_ver_patologia = ver_patologia
        m_ver_calidad_de_leche = ver_calidad_de_leche
        m_tecnico_1 = tecnico_1
        m_fecha_tecnico = fecha_tecnico
        m_id_usuario_asigna_tecnico = id_usuario_asigna_tecnico
        m_tecnico_2 = tecnico_2
        m_tecnico_3 = tecnico_3
        m_tecnico_4 = tecnico_4
        m_codigofigaro = codigofigaro
        m_enviar_informe_por_mail = enviar_informe_por_email
        m_path_estado_de_cuenta = path_estado_de_cuenta
        m_fecha_modificacion = fecha_modificacion

    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pProductorWeb_uy
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pProductorWeb_uy
        Return p.modificar(Me, usuario)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pProductorWeb_uy
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dProductorWeb_uy
        Dim p As New pProductorWeb_uy
        Return p.buscar(Me)
    End Function
    Public Function buscarPorNombre(ByVal pnombre As String) As ArrayList
        Dim s As New pProductorWeb_uy
        Return s.buscarPorNombre(pnombre)
    End Function
    Public Function buscarPorUsuario(ByVal productorweb As String) As ArrayList
        Dim s As New pProductorWeb_uy
        Return s.buscarPorUsuario(productorweb)
    End Function
    Public Function buscarPorId(ByVal texto As String) As ArrayList
        Dim s As New pProductorWeb_uy
        Return s.buscarPorUsuario(texto)
    End Function
#End Region

    Public Overrides Function ToString() As String
        Return m_nombre
    End Function
    Public Function listar() As ArrayList
        Dim p As New pProductorWeb_uy
        Return p.listar
    End Function
End Class
