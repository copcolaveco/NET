Public Class dUsuarioGestor
    Private m_id As Long
    Private m_idnet As Long
    Private m_usuario As String
    Private m_nombre As String
    Private m_direccion As String
    Private m_dicose As String
    Private m_rsocial As String
    Private m_cedula As String
    Private m_rut As String
    Private m_password As String
    Private m_password_confirmation As String
    Private m_email As String
    Private m_direccion_frasco As String
    Private m_agencia_frasco As Integer
    Private m_notificacion_frasco_1 As String
    Private m_notificacion_frasco_2 As String
    Private m_notificacion_solicitud_1 As String
    Private m_notificacion_solicitud_2 As String
    Private m_notificacion_resultado_1 As String
    Private m_notificacion_resultado_2 As String
    Private m_notificacion_avisos_1 As String
    Private m_notificacion_avisos_2 As String
    Private m_tecnico_celular_1 As String
    Private m_tecnico_celular_2 As String
    Private m_tecnico_celular_nombre_1 As String
    Private m_tecnico_celular_nombre_2 As String
    Private m_tecnico_telefono_1 As String
    Private m_tecnico_telefono_2 As String
    Private m_tecnico_telefono_nombre_1 As String
    Private m_tecnico_telefono_nombre_2 As String
    Private m_tecnico_email_1 As String
    Private m_tecnico_email_2 As String
    Private m_tecnico_email_nombre_1 As String
    Private m_tecnico_email_nombre_2 As String
    Private m_tipo_documento As String
    Private m_documento As String
    Private m_fac_direccion As String
    Private m_fac_localidad As String
    Private m_fac_departamento As Integer
    Private m_fac_email_envio As String
    Private m_cobranza_celular_1 As String
    Private m_cobranza_celular_2 As String
    Private m_cobranza_celular_nombre_1 As String
    Private m_cobranza_celular_nombre_2 As String
    Private m_cobranza_telefono_1 As String
    Private m_cobranza_telefono_2 As String
    Private m_cobranza_telefono_nombre_1 As String
    Private m_cobranza_telefono_nombre_2 As String
    Private m_cobranza_email_1 As String
    Private m_cobranza_email_2 As String
    Private m_cobranza_email_nombre_1 As String
    Private m_cobranza_email_nombre_2 As String
    Private m_admin As Boolean
    Private m_id_tecnico_1 As Long
    Private m_id_tecnico_2 As Long


#Region "Getters y Setters"
    Public Property id() As Long
        Get
            Return m_id
        End Get
        Set(ByVal value As Long)
            m_id = value
        End Set
    End Property
    Public Property idnet() As Long
        Get
            Return m_idnet
        End Get
        Set(ByVal value As Long)
            m_idnet = value
        End Set
    End Property
    Public Property usuario_web() As String
        Get
            Return m_usuario
        End Get
        Set(ByVal value As String)
            m_usuario = value
        End Set
    End Property
    Public Property nombre() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property direccion() As String
        Get
            Return m_direccion
        End Get
        Set(ByVal value As String)
            m_direccion = value
        End Set
    End Property
    Public Property dicose() As String
        Get
            Return m_dicose
        End Get
        Set(ByVal value As String)
            m_dicose = value
        End Set
    End Property
    Public Property razon_social() As String
        Get
            Return m_rsocial
        End Get
        Set(ByVal value As String)
            m_rsocial = value
        End Set
    End Property
    Public Property cedula() As String
        Get
            Return m_cedula
        End Get
        Set(ByVal value As String)
            m_cedula = value
        End Set
    End Property
    Public Property rut() As String
        Get
            Return m_rut
        End Get
        Set(ByVal value As String)
            m_rut = value
        End Set
    End Property
    Public Property password() As String
        Get
            Return m_password
        End Get
        Set(ByVal value As String)
            m_password = value
        End Set
    End Property
    Public Property password_confirmation() As String
        Get
            Return m_password_confirmation
        End Get
        Set(ByVal value As String)
            m_password_confirmation = value
        End Set
    End Property
    Public Property email() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property
    Public Property direccion_frasco() As String
        Get
            Return m_direccion_frasco
        End Get
        Set(ByVal value As String)
            m_direccion_frasco = value
        End Set
    End Property
    Public Property agencia_frasco() As Integer
        Get
            Return m_agencia_frasco
        End Get
        Set(ByVal value As Integer)
            m_agencia_frasco = value
        End Set
    End Property
    Public Property notificacion_frasco_1() As String
        Get
            Return m_notificacion_frasco_1
        End Get
        Set(ByVal value As String)
            m_notificacion_frasco_1 = value
        End Set
    End Property
    Public Property notificacion_frasco_2() As String
        Get
            Return m_notificacion_frasco_2
        End Get
        Set(ByVal value As String)
            m_notificacion_frasco_2 = value
        End Set
    End Property
    Public Property notificacion_solicitud_1() As String
        Get
            Return m_notificacion_solicitud_1
        End Get
        Set(ByVal value As String)
            m_notificacion_solicitud_1 = value
        End Set
    End Property
    Public Property notificacion_solicitud_2() As String
        Get
            Return m_notificacion_solicitud_2
        End Get
        Set(ByVal value As String)
            m_notificacion_solicitud_2 = value
        End Set
    End Property
    Public Property notificacion_resultado_1() As String
        Get
            Return m_notificacion_resultado_1
        End Get
        Set(ByVal value As String)
            m_notificacion_resultado_1 = value
        End Set
    End Property
    Public Property notificacion_resultado_2() As String
        Get
            Return m_notificacion_resultado_2
        End Get
        Set(ByVal value As String)
            m_notificacion_resultado_2 = value
        End Set
    End Property
    Public Property notificacion_avisos_1() As String
        Get
            Return m_notificacion_avisos_1
        End Get
        Set(ByVal value As String)
            m_notificacion_avisos_1 = value
        End Set
    End Property
    Public Property notificacion_avisos_2() As String
        Get
            Return m_notificacion_avisos_2
        End Get
        Set(ByVal value As String)
            m_notificacion_avisos_2 = value
        End Set
    End Property
    Public Property tecnico_celular_1() As String
        Get
            Return m_tecnico_celular_1
        End Get
        Set(ByVal value As String)
            m_tecnico_celular_1 = value
        End Set
    End Property
    Public Property tecnico_celular_2() As String
        Get
            Return m_tecnico_celular_2
        End Get
        Set(ByVal value As String)
            m_tecnico_celular_2 = value
        End Set
    End Property
    Public Property tecnico_celular_nombre_1() As String
        Get
            Return m_tecnico_celular_nombre_1
        End Get
        Set(ByVal value As String)
            m_tecnico_celular_nombre_1 = value
        End Set
    End Property
    Public Property tecnico_celular_nombre_2() As String
        Get
            Return m_tecnico_celular_nombre_2
        End Get
        Set(ByVal value As String)
            m_tecnico_celular_nombre_2 = value
        End Set
    End Property
    Public Property tecnico_telefono_1() As String
        Get
            Return m_tecnico_telefono_1
        End Get
        Set(ByVal value As String)
            m_tecnico_telefono_1 = value
        End Set
    End Property
    Public Property tecnico_telefono_2() As String
        Get
            Return m_tecnico_telefono_2
        End Get
        Set(ByVal value As String)
            m_tecnico_telefono_2 = value
        End Set
    End Property
    Public Property tecnico_telefono_nombre_1() As String
        Get
            Return m_tecnico_telefono_nombre_1
        End Get
        Set(ByVal value As String)
            m_tecnico_telefono_nombre_1 = value
        End Set
    End Property
    Public Property tecnico_telefono_nombre_2() As String
        Get
            Return m_tecnico_telefono_nombre_2
        End Get
        Set(ByVal value As String)
            m_tecnico_telefono_nombre_2 = value
        End Set
    End Property
    Public Property tecnico_email_1() As String
        Get
            Return m_tecnico_email_1
        End Get
        Set(ByVal value As String)
            m_tecnico_email_1 = value
        End Set
    End Property
    Public Property tecnico_email_2() As String
        Get
            Return m_tecnico_email_2
        End Get
        Set(ByVal value As String)
            m_tecnico_email_2 = value
        End Set
    End Property
    Public Property tecnico_email_nombre_1() As String
        Get
            Return m_tecnico_email_nombre_1
        End Get
        Set(ByVal value As String)
            m_tecnico_email_nombre_1 = value
        End Set
    End Property
    Public Property tecnico_email_nombre_2() As String
        Get
            Return m_tecnico_email_nombre_2
        End Get
        Set(ByVal value As String)
            m_tecnico_email_nombre_2 = value
        End Set
    End Property
    Public Property tipo_documento() As String
        Get
            Return m_tipo_documento
        End Get
        Set(ByVal value As String)
            m_tipo_documento = value
        End Set
    End Property
    Public Property documento() As String
        Get
            Return m_documento
        End Get
        Set(ByVal value As String)
            m_documento = value
        End Set
    End Property
    Public Property fac_direccion() As String
        Get
            Return m_fac_direccion
        End Get
        Set(ByVal value As String)
            m_fac_direccion = value
        End Set
    End Property
    Public Property fac_localidad() As String
        Get
            Return m_fac_localidad
        End Get
        Set(ByVal value As String)
            m_fac_localidad = value
        End Set
    End Property
    Public Property fac_departamento() As Integer
        Get
            Return m_fac_departamento
        End Get
        Set(ByVal value As Integer)
            m_fac_departamento = value
        End Set
    End Property
    Public Property fac_email_envio() As String
        Get
            Return m_fac_email_envio
        End Get
        Set(ByVal value As String)
            m_fac_email_envio = value
        End Set
    End Property
    Public Property cobranza_celular_1() As String
        Get
            Return m_cobranza_celular_1
        End Get
        Set(ByVal value As String)
            m_cobranza_celular_1 = value
        End Set
    End Property
    Public Property cobranza_celular_2() As String
        Get
            Return m_cobranza_celular_2
        End Get
        Set(ByVal value As String)
            m_cobranza_celular_2 = value
        End Set
    End Property
    Public Property cobranza_celular_nombre_1() As String
        Get
            Return m_cobranza_celular_nombre_1
        End Get
        Set(ByVal value As String)
            m_cobranza_celular_nombre_1 = value
        End Set
    End Property
    Public Property cobranza_celular_nombre_2() As String
        Get
            Return m_cobranza_celular_nombre_2
        End Get
        Set(ByVal value As String)
            m_cobranza_celular_nombre_2 = value
        End Set
    End Property
    Public Property cobranza_telefono_1() As String
        Get
            Return m_cobranza_telefono_1
        End Get
        Set(ByVal value As String)
            m_cobranza_telefono_1 = value
        End Set
    End Property
    Public Property cobranza_telefono_2() As String
        Get
            Return m_cobranza_telefono_2
        End Get
        Set(ByVal value As String)
            m_cobranza_telefono_2 = value
        End Set
    End Property
    Public Property cobranza_telefono_nombre_1() As String
        Get
            Return m_cobranza_telefono_nombre_1
        End Get
        Set(ByVal value As String)
            m_cobranza_telefono_nombre_1 = value
        End Set
    End Property
    Public Property cobranza_telefono_nombre_2() As String
        Get
            Return m_cobranza_telefono_nombre_2
        End Get
        Set(ByVal value As String)
            m_cobranza_telefono_nombre_2 = value
        End Set
    End Property
    Public Property cobranza_email_1() As String
        Get
            Return m_cobranza_email_1
        End Get
        Set(ByVal value As String)
            m_cobranza_email_1 = value
        End Set
    End Property
    Public Property cobranza_email_2() As String
        Get
            Return m_cobranza_email_2
        End Get
        Set(ByVal value As String)
            m_cobranza_email_2 = value
        End Set
    End Property
    Public Property cobranza_email_nombre_1() As String
        Get
            Return m_cobranza_email_nombre_1
        End Get
        Set(ByVal value As String)
            m_cobranza_email_nombre_1 = value
        End Set
    End Property
    Public Property cobranza_email_nombre_2() As String
        Get
            Return m_cobranza_email_nombre_2
        End Get
        Set(ByVal value As String)
            m_cobranza_email_nombre_2 = value
        End Set
    End Property
    Public Property admin() As Boolean
        Get
            Return m_admin
        End Get
        Set(ByVal value As Boolean)
            m_admin = value
        End Set
    End Property
    Public Property id_tecnico_1() As Long
        Get
            Return m_id_tecnico_1
        End Get
        Set(ByVal value As Long)
            m_id_tecnico_1 = value
        End Set
    End Property
    Public Property id_tecnico_2() As Long
        Get
            Return m_id_tecnico_2
        End Get
        Set(ByVal value As Long)
            m_id_tecnico_2 = value
        End Set
    End Property
#End Region
End Class
