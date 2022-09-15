Public Class dCliente
#Region "Atributos"
    Private m_id As Long
    Private m_nombre As String
    Private m_email As String
    Private m_nombre_email1 As String
    Private m_email1 As String
    Private m_nombre_email2 As String
    Private m_email2 As String
    Private m_envio As String
    Private m_usuario_web As String
    Private m_nombre_celular1 As String
    Private m_celular As String
    Private m_nombre_celular2 As String
    Private m_celular2 As String
    Private m_codigofigaro As String
    Private m_tipousuario As Integer
    Private m_direccion As String
    Private m_nombre_telefono1 As String
    Private m_telefono1 As String
    Private m_nombre_telefono2 As String
    Private m_telefono2 As String
    Private m_fax As String
    Private m_dicose As String
    Private m_iddepartamento As Integer
    Private m_idlocalidad As Integer
    Private m_tecnico1 As Long
    Private m_tecnico2 As Long
    Private m_idagencia As Integer
    Private m_contrato As Integer
    Private m_socio As Integer
    Private m_nousar As Integer
    Private m_codbar As Integer
    Private m_caravanas As Integer
    Private m_prolesa As Integer
    Private m_prolesasuc As Integer
    Private m_prolesamat As Long
    Private m_observaciones As String
    Private m_fac_rsocial As String
    Private m_fac_cedula As String
    Private m_fac_rut As String
    Private m_fac_direccion As String
    Private m_fac_localidad As String
    Private m_fac_departamento As Integer
    Private m_fac_cpostal As String
    Private m_fac_giro As Integer
    Private m_cob_nombre_telefono1 As String
    Private m_fac_telefonos As String
    Private m_cob_nombre_telefono2 As String
    Private m_cob_telefono2 As String
    Private m_cob_nombre_celular1 As String
    Private m_cob_celular1 As String
    Private m_cob_nombre_celular2 As String
    Private m_cob_celular2 As String
    Private m_cob_nombre_email1 As String
    Private m_cob_email1 As String
    Private m_cob_nombre_email2 As String
    Private m_cob_email2 As String
    Private m_fac_fax As String
    Private m_fac_email As String
    Private m_fac_contacto As String
    Private m_fac_observaciones As String
    Private m_fac_lista As Integer
    Private m_fac_contado As Integer
    Private m_not_nombre_email_frascos1 As String
    Private m_not_email_frascos1 As String
    Private m_not_nombre_email_frascos2 As String
    Private m_not_email_frascos2 As String
    Private m_not_nombre_email_muestras1 As String
    Private m_not_email_muestras1 As String
    Private m_not_nombre_email_muestras2 As String
    Private m_not_email_muestras2 As String
    Private m_not_nombre_email_analisis1 As String
    Private m_not_email_analisis1 As String
    Private m_not_nombre_email_analisis2 As String
    Private m_not_email_analisis2 As String
    Private m_not_nombre_email_general1 As String
    Private m_not_email_general1 As String
    Private m_not_nombre_email_general2 As String
    Private m_not_email_general2 As String
    Private m_incobrable As Integer
    Private m_tecnico_suelo_nutri As Integer
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
    Public Property NOMBRE() As String
        Get
            Return m_nombre
        End Get
        Set(ByVal value As String)
            m_nombre = value
        End Set
    End Property
    Public Property EMAIL() As String
        Get
            Return m_email
        End Get
        Set(ByVal value As String)
            m_email = value
        End Set
    End Property
    Public Property NOMBRE_EMAIL1() As String
        Get
            Return m_nombre_email1
        End Get
        Set(ByVal value As String)
            m_nombre_email1 = value
        End Set
    End Property
    Public Property EMAIL1() As String
        Get
            Return m_email1
        End Get
        Set(ByVal value As String)
            m_email1 = value
        End Set
    End Property
    Public Property NOMBRE_EMAIL2() As String
        Get
            Return m_nombre_email2
        End Get
        Set(ByVal value As String)
            m_nombre_email2 = value
        End Set
    End Property
    Public Property EMAIL2() As String
        Get
            Return m_email2
        End Get
        Set(ByVal value As String)
            m_email2 = value
        End Set
    End Property
    Public Property ENVIO() As String
        Get
            Return m_envio
        End Get
        Set(ByVal value As String)
            m_envio = value
        End Set
    End Property
    Public Property USUARIO_WEB() As String
        Get
            Return m_usuario_web
        End Get
        Set(ByVal value As String)
            m_usuario_web = value
        End Set
    End Property
    Public Property NOMBRE_CELULAR1() As String
        Get
            Return m_nombre_celular1
        End Get
        Set(ByVal value As String)
            m_nombre_celular1 = value
        End Set
    End Property
    Public Property CELULAR() As String
        Get
            Return m_celular
        End Get
        Set(ByVal value As String)
            m_celular = value
        End Set
    End Property
    Public Property NOMBRE_CELULAR2() As String
        Get
            Return m_nombre_celular2
        End Get
        Set(ByVal value As String)
            m_nombre_celular2 = value
        End Set
    End Property
    Public Property CELULAR2() As String
        Get
            Return m_celular2
        End Get
        Set(ByVal value As String)
            m_celular2 = value
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
    Public Property TIPOUSUARIO() As String
        Get
            Return m_tipousuario
        End Get
        Set(ByVal value As String)
            m_tipousuario = value
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
    Public Property NOMBRE_TELEFONO1() As String
        Get
            Return m_nombre_telefono1
        End Get
        Set(ByVal value As String)
            m_nombre_telefono1 = value
        End Set
    End Property
    Public Property TELEFONO1() As String
        Get
            Return m_telefono1
        End Get
        Set(ByVal value As String)
            m_telefono1 = value
        End Set
    End Property
    Public Property NOMBRE_TELEFONO2() As String
        Get
            Return m_nombre_telefono2
        End Get
        Set(ByVal value As String)
            m_nombre_telefono2 = value
        End Set
    End Property
    Public Property TELEFONO2() As String
        Get
            Return m_telefono2
        End Get
        Set(ByVal value As String)
            m_telefono2 = value
        End Set
    End Property
    Public Property FAX() As String
        Get
            Return m_fax
        End Get
        Set(ByVal value As String)
            m_fax = value
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
    Public Property IDDEPARTAMENTO() As Integer
        Get
            Return m_iddepartamento
        End Get
        Set(ByVal value As Integer)
            m_iddepartamento = value
        End Set
    End Property
    Public Property IDLOCALIDAD() As Integer
        Get
            Return m_idlocalidad
        End Get
        Set(ByVal value As Integer)
            m_idlocalidad = value
        End Set
    End Property
    Public Property TECNICO1() As Long
        Get
            Return m_tecnico1
        End Get
        Set(ByVal value As Long)
            m_tecnico1 = value
        End Set
    End Property
    Public Property TECNICO2() As Long
        Get
            Return m_tecnico2
        End Get
        Set(ByVal value As Long)
            m_tecnico2 = value
        End Set
    End Property
    Public Property IDAGENCIA() As Integer
        Get
            Return m_idagencia
        End Get
        Set(ByVal value As Integer)
            m_idagencia = value
        End Set
    End Property
    Public Property CONTRATO() As Integer
        Get
            Return m_contrato
        End Get
        Set(ByVal value As Integer)
            m_contrato = value
        End Set
    End Property
    Public Property SOCIO() As Integer
        Get
            Return m_socio
        End Get
        Set(ByVal value As Integer)
            m_socio = value
        End Set
    End Property
    Public Property NOUSAR() As Integer
        Get
            Return m_nousar
        End Get
        Set(ByVal value As Integer)
            m_nousar = value
        End Set
    End Property
    Public Property CODBAR() As Integer
        Get
            Return m_codbar
        End Get
        Set(ByVal value As Integer)
            m_codbar = value
        End Set
    End Property
    Public Property CARAVANAS() As Integer
        Get
            Return m_caravanas
        End Get
        Set(ByVal value As Integer)
            m_caravanas = value
        End Set
    End Property
    Public Property PROLESA() As Integer
        Get
            Return m_prolesa
        End Get
        Set(ByVal value As Integer)
            m_prolesa = value
        End Set
    End Property
    Public Property PROLESASUC() As Integer
        Get
            Return m_prolesasuc
        End Get
        Set(ByVal value As Integer)
            m_prolesasuc = value
        End Set
    End Property
    Public Property PROLESAMAT() As Long
        Get
            Return m_prolesamat
        End Get
        Set(ByVal value As Long)
            m_prolesamat = value
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
    Public Property FAC_RSOCIAL() As String
        Get
            Return m_fac_rsocial
        End Get
        Set(ByVal value As String)
            m_fac_rsocial = value
        End Set
    End Property
    Public Property FAC_CEDULA() As String
        Get
            Return m_fac_cedula
        End Get
        Set(ByVal value As String)
            m_fac_cedula = value
        End Set
    End Property
    Public Property FAC_RUT() As String
        Get
            Return m_fac_rut
        End Get
        Set(ByVal value As String)
            m_fac_rut = value
        End Set
    End Property
    Public Property FAC_DIRECCION() As String
        Get
            Return m_fac_direccion
        End Get
        Set(ByVal value As String)
            m_fac_direccion = value
        End Set
    End Property
    Public Property FAC_LOCALIDAD() As String
        Get
            Return m_fac_localidad
        End Get
        Set(ByVal value As String)
            m_fac_localidad = value
        End Set
    End Property
    Public Property FAC_DEPARTAMENTO() As Integer
        Get
            Return m_fac_departamento
        End Get
        Set(ByVal value As Integer)
            m_fac_departamento = value
        End Set
    End Property
    Public Property FAC_CPOSTAL() As String
        Get
            Return m_fac_cpostal
        End Get
        Set(ByVal value As String)
            m_fac_cpostal = value
        End Set
    End Property
    Public Property FAC_GIRO() As Integer
        Get
            Return m_fac_giro
        End Get
        Set(ByVal value As Integer)
            m_fac_giro = value
        End Set
    End Property
    Public Property COB_NOMBRE_TELEFONO1() As String
        Get
            Return m_cob_nombre_telefono1
        End Get
        Set(ByVal value As String)
            m_cob_nombre_telefono1 = value
        End Set
    End Property
    Public Property FAC_TELEFONOS() As String
        Get
            Return m_fac_telefonos
        End Get
        Set(ByVal value As String)
            m_fac_telefonos = value
        End Set
    End Property
    Public Property COB_NOMBRE_TELEFONO2() As String
        Get
            Return m_cob_nombre_telefono2
        End Get
        Set(ByVal value As String)
            m_cob_nombre_telefono2 = value
        End Set
    End Property
    Public Property COB_TELEFONO2() As String
        Get
            Return m_cob_telefono2
        End Get
        Set(ByVal value As String)
            m_cob_telefono2 = value
        End Set
    End Property
    Public Property COB_NOMBRE_CELULAR1() As String
        Get
            Return m_cob_nombre_celular1
        End Get
        Set(ByVal value As String)
            m_cob_nombre_celular1 = value
        End Set
    End Property
    Public Property COB_CELULAR1() As String
        Get
            Return m_cob_celular1
        End Get
        Set(ByVal value As String)
            m_cob_celular1 = value
        End Set
    End Property
    Public Property COB_NOMBRE_CELULAR2() As String
        Get
            Return m_cob_nombre_celular2
        End Get
        Set(ByVal value As String)
            m_cob_nombre_celular2 = value
        End Set
    End Property
    Public Property COB_CELULAR2() As String
        Get
            Return m_cob_celular2
        End Get
        Set(ByVal value As String)
            m_cob_celular2 = value
        End Set
    End Property
    Public Property COB_NOMBRE_EMAIL1() As String
        Get
            Return m_cob_nombre_email1
        End Get
        Set(ByVal value As String)
            m_cob_nombre_email1 = value
        End Set
    End Property
    Public Property COB_EMAIL1() As String
        Get
            Return m_cob_email1
        End Get
        Set(ByVal value As String)
            m_cob_email1 = value
        End Set
    End Property
    Public Property COB_NOMBRE_EMAIL2() As String
        Get
            Return m_cob_nombre_email2
        End Get
        Set(ByVal value As String)
            m_cob_nombre_email2 = value
        End Set
    End Property
    Public Property COB_EMAIL2() As String
        Get
            Return m_cob_email2
        End Get
        Set(ByVal value As String)
            m_cob_email2 = value
        End Set
    End Property
    Public Property FAC_FAX() As String
        Get
            Return m_fac_fax
        End Get
        Set(ByVal value As String)
            m_fac_fax = value
        End Set
    End Property
    Public Property FAC_EMAIL() As String
        Get
            Return m_fac_email
        End Get
        Set(ByVal value As String)
            m_fac_email = value
        End Set
    End Property
    Public Property FAC_CONTACTO() As String
        Get
            Return m_fac_contacto
        End Get
        Set(ByVal value As String)
            m_fac_contacto = value
        End Set
    End Property
    Public Property FAC_OBSERVACIONES() As String
        Get
            Return m_fac_observaciones
        End Get
        Set(ByVal value As String)
            m_fac_observaciones = value
        End Set
    End Property
    Public Property FAC_LISTA() As Integer
        Get
            Return m_fac_lista
        End Get
        Set(ByVal value As Integer)
            m_fac_lista = value
        End Set
    End Property
    Public Property FAC_CONTADO() As Integer
        Get
            Return m_fac_contado
        End Get
        Set(ByVal value As Integer)
            m_fac_contado = value
        End Set
    End Property
    Public Property NOT_EMAIL_FRASCOS1() As String
        Get
            Return m_not_email_frascos1
        End Get
        Set(ByVal value As String)
            m_not_email_frascos1 = value
        End Set
    End Property
    Public Property NOT_EMAIL_FRASCOS2() As String
        Get
            Return m_not_email_frascos2
        End Get
        Set(ByVal value As String)
            m_not_email_frascos2 = value
        End Set
    End Property
    Public Property NOT_EMAIL_MUESTRAS1() As String
        Get
            Return m_not_email_muestras1
        End Get
        Set(ByVal value As String)
            m_not_email_muestras1 = value
        End Set
    End Property
    Public Property NOT_EMAIL_MUESTRAS2() As String
        Get
            Return m_not_email_muestras2
        End Get
        Set(ByVal value As String)
            m_not_email_muestras2 = value
        End Set
    End Property
    Public Property NOT_EMAIL_ANALISIS1() As String
        Get
            Return m_not_email_analisis1
        End Get
        Set(ByVal value As String)
            m_not_email_analisis1 = value
        End Set
    End Property
    Public Property NOT_EMAIL_ANALISIS2() As String
        Get
            Return m_not_email_analisis2
        End Get
        Set(ByVal value As String)
            m_not_email_analisis2 = value
        End Set
    End Property
    Public Property NOT_EMAIL_GENERAL1() As String
        Get
            Return m_not_email_general1
        End Get
        Set(ByVal value As String)
            m_not_email_general1 = value
        End Set
    End Property
    Public Property NOT_EMAIL_GENERAL2() As String
        Get
            Return m_not_email_general2
        End Get
        Set(ByVal value As String)
            m_not_email_general2 = value
        End Set
    End Property
    Public Property INCOBRABLE() As Integer
        Get
            Return m_incobrable
        End Get
        Set(ByVal value As Integer)
            m_incobrable = value
        End Set
    End Property
    Public Property TECNICO_SUELO_NUTRI() As Integer
        Get
            Return m_tecnico_suelo_nutri
        End Get
        Set(ByVal value As Integer)
            m_tecnico_suelo_nutri = value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New()
        m_id = 0
        m_nombre = ""
        m_email = ""
        m_nombre_email1 = ""
        m_email1 = ""
        m_nombre_email2 = ""
        m_email2 = ""
        m_envio = ""
        m_usuario_web = ""
        m_nombre_celular1 = ""
        m_celular = ""
        m_nombre_celular2 = ""
        m_celular2 = ""
        m_codigofigaro = ""
        m_tipousuario = 0
        m_direccion = ""
        m_nombre_telefono1 = ""
        m_telefono1 = ""
        m_nombre_telefono2 = ""
        m_telefono2 = ""
        m_fax = ""
        m_dicose = ""
        m_iddepartamento = 0
        m_idlocalidad = 0
        m_tecnico1 = 0
        m_tecnico2 = 0
        m_idagencia = 0
        m_contrato = 0
        m_socio = 0
        m_nousar = 0
        m_codbar = 0
        m_caravanas = 0
        m_prolesa = 0
        m_prolesasuc = 0
        m_prolesamat = 0
        m_observaciones = ""
        m_fac_rsocial = ""
        m_fac_cedula = ""
        m_fac_rut = ""
        m_fac_direccion = ""
        m_fac_localidad = ""
        m_fac_departamento = 0
        m_fac_cpostal = ""
        m_fac_giro = 0
        m_cob_nombre_telefono1 = ""
        m_fac_telefonos = ""
        m_cob_nombre_telefono2 = ""
        m_cob_telefono2 = ""
        m_cob_nombre_celular1 = ""
        m_cob_celular1 = ""
        m_cob_nombre_celular2 = ""
        m_cob_celular2 = ""
        m_cob_nombre_email1 = ""
        m_cob_email1 = ""
        m_cob_nombre_email2 = ""
        m_cob_email2 = ""
        m_fac_fax = ""
        m_fac_email = ""
        m_fac_contacto = ""
        m_fac_observaciones = ""
        m_fac_lista = 0
        m_fac_contado = 0
        m_not_email_frascos1 = ""
        m_not_email_frascos2 = ""
        m_not_email_muestras1 = ""
        m_not_email_muestras2 = ""
        m_not_email_analisis1 = ""
        m_not_email_analisis2 = ""
        m_not_email_general1 = ""
        m_not_email_general2 = ""
        m_incobrable = 0
        m_tecnico_suelo_nutri = 0
    End Sub
    Public Sub New(ByVal id As Long, ByVal nombre As String, ByVal email As String, ByVal nombre_email1 As String, ByVal email1 As String, ByVal nombre_email2 As String, ByVal email2 As String, ByVal envio As String, ByVal usuario_web As String, ByVal nombre_celular1 As String, ByVal celular As String, ByVal nombre_celular2 As String, ByVal celular2 As String, ByVal codigofigaro As String, ByVal tipousuario As Integer, ByVal direccion As String, ByVal nombre_telefono1 As String, ByVal telefono1 As String, ByVal nombre_telefono2 As String, ByVal telefono2 As String, ByVal fax As String, ByVal dicose As String, ByVal iddepartamento As Integer, ByVal idlocalidad As Integer, ByVal tecnico1 As Long, ByVal tecnico2 As Long, ByVal idagencia As Integer, ByVal contrato As Integer, ByVal socio As Integer, ByVal nousar As Integer, ByVal codbar As Integer, ByVal caravanas As Integer, ByVal prolesa As Integer, ByVal prolesasuc As Integer, ByVal prolesamat As Long, ByVal observaciones As String, ByVal fac_rsocial As String, ByVal fac_cedula As String, ByVal fac_rut As String, ByVal fac_direccion As String, ByVal fac_localidad As String, ByVal fac_departamento As Integer, ByVal fac_cpostal As String, ByVal fac_giro As Integer, ByVal cob_nombre_telefono1 As String, ByVal fac_telefonos As String, ByVal cob_nombre_telefono2 As String, ByVal cob_telefono2 As String, ByVal cob_nombre_celular1 As String, ByVal cob_celular1 As String, ByVal cob_nombre_celular2 As String, ByVal cob_celular2 As String, ByVal cob_nombre_email1 As String, ByVal cob_email1 As String, ByVal cob_nombre_email2 As String, ByVal cob_email2 As String, ByVal fac_fax As String, ByVal fac_email As String, ByVal fac_contacto As String, ByVal fac_observaciones As String, ByVal fac_lista As Integer, ByVal fac_contado As Integer, ByVal not_nombre_email_frascos1 As String, ByVal not_email_frascos1 As String, ByVal not_nombre_email_frascos2 As String, ByVal not_email_frascos2 As String, ByVal not_nombre_email_muestras1 As String, ByVal not_email_muestras1 As String, ByVal not_nombre_email_muestras2 As String, ByVal not_email_muestras2 As String, ByVal not_nombre_email_analisis1 As String, ByVal not_email_analisis1 As String, ByVal not_nombre_email_analisis2 As String, ByVal not_email_analisis2 As String, ByVal not_nombre_email_general1 As String, ByVal not_email_general1 As String, ByVal not_nombre_email_general2 As String, ByVal not_email_general2 As String, ByVal incobrable As Integer, ByVal tecnico_suelo_nutri As Integer)
        m_id = id
        m_nombre = nombre
        m_email = email
        m_nombre_email1 = nombre_email1
        m_email1 = email1
        m_nombre_email2 = nombre_email2
        m_email2 = email2
        m_envio = envio
        m_usuario_web = usuario_web
        m_nombre_celular1 = nombre_celular1
        m_celular = celular
        m_nombre_celular2 = nombre_celular2
        m_celular2 = celular2
        m_codigofigaro = codigofigaro
        m_tipousuario = tipousuario
        m_direccion = direccion
        m_nombre_telefono1 = nombre_telefono1
        m_telefono1 = telefono1
        m_nombre_telefono2 = nombre_telefono2
        m_telefono2 = telefono2
        m_fax = fax
        m_dicose = dicose
        m_iddepartamento = iddepartamento
        m_idlocalidad = idlocalidad
        m_tecnico1 = tecnico1
        m_tecnico2 = tecnico2
        m_idagencia = idagencia
        m_contrato = contrato
        m_socio = socio
        m_nousar = nousar
        m_codbar = codbar
        m_caravanas = caravanas
        m_prolesa = prolesa
        m_prolesasuc = prolesasuc
        m_prolesamat = prolesamat
        m_observaciones = observaciones
        m_fac_rsocial = fac_rsocial
        m_fac_cedula = fac_cedula
        m_fac_rut = fac_rut
        m_fac_direccion = fac_direccion
        m_fac_localidad = fac_localidad
        m_fac_departamento = fac_departamento
        m_fac_cpostal = fac_cpostal
        m_fac_giro = fac_giro
        m_cob_nombre_telefono1 = cob_nombre_telefono1
        m_fac_telefonos = fac_telefonos
        m_cob_nombre_telefono2 = cob_nombre_telefono2
        m_cob_telefono2 = cob_telefono2
        m_cob_nombre_celular1 = cob_nombre_celular1
        m_cob_celular1 = cob_celular1
        m_cob_nombre_celular2 = cob_nombre_celular2
        m_cob_celular2 = cob_celular2
        m_cob_nombre_email1 = cob_nombre_email1
        m_cob_email1 = cob_email1
        m_cob_nombre_email2 = cob_nombre_email2
        m_cob_email2 = cob_email2
        m_fac_fax = fac_fax
        m_fac_email = fac_email
        m_fac_contacto = fac_contacto
        m_fac_observaciones = fac_observaciones
        m_fac_lista = fac_lista
        m_fac_contado = fac_contado
        m_not_email_frascos1 = not_email_frascos1
        m_not_email_frascos2 = not_email_frascos2
        m_not_email_muestras1 = not_email_muestras1
        m_not_email_muestras2 = not_email_muestras2
        m_not_email_analisis1 = not_email_analisis1
        m_not_email_analisis2 = not_email_analisis2
        m_not_email_general1 = not_email_general1
        m_not_email_general2 = not_email_general2
        m_incobrable = incobrable
        m_tecnico_suelo_nutri = tecnico_suelo_nutri
    End Sub
#End Region

#Region "Métodos ABM"
    Public Function guardar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCliente
        Return p.guardar(Me, usuario)
    End Function
    Public Function modificar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCliente
        Return p.modificar(Me, usuario)
    End Function
    Public Function marcarcaravana(ByVal usuario As dUsuario, ByVal cli As Integer) As Boolean
        Dim p As New pCliente
        Return p.marcarcaravana(usuario, cli)
    End Function
    Public Function desmarcarcaravana(ByVal usuario As dUsuario, ByVal cli As Integer) As Boolean
        Dim p As New pCliente
        Return p.desmarcarcaravana(usuario, cli)
    End Function
    Public Function eliminar(ByVal usuario As dUsuario) As Boolean
        Dim p As New pCliente
        Return p.eliminar(Me, usuario)
    End Function
    Public Function buscar() As dCliente
        Dim p As New pCliente
        Return p.buscar(Me)
    End Function
    Public Function buscarxCodigoFigaro() As dCliente
        Dim p As New pCliente
        Return p.buscarxCodigoFigaro(Me)
    End Function
    Public Function buscarPorNombreTodos(ByVal pnombre As String) As ArrayList
        Dim s As New pCliente
        Return s.buscarPorNombreTodos(pnombre)
    End Function
    Public Function buscarPorNombre(ByVal pnombre As String) As ArrayList
        Dim s As New pCliente
        Return s.buscarPorNombre(pnombre)
    End Function
    Public Function buscarPorDicose(ByVal pdicose As String) As ArrayList
        Dim s As New pCliente
        Return s.buscarPorDicose(pdicose)
    End Function
    Public Function buscarPorNombreEmpresa(ByVal pnombre As String) As ArrayList
        Dim s As New pCliente
        Return s.buscarPorNombreEmpresa(pnombre)
    End Function
    Public Function buscarPorUsuarioWeb() As dCliente
        Dim p As New pCliente
        Return p.buscarPorUsuarioWeb(Me)
    End Function

    Public Function buscarPorId(ByVal pid As Long) As ArrayList
        Dim s As New pCliente
        Return s.buscarPorId(pid)
    End Function
    Public Function buscarPorId2(ByVal pid As Long) As dCliente
        Dim s As New pCliente
        Return s.buscarPorId2(pid)
    End Function


    Public Function buscarultimo() As dCliente
        Dim s As New pCliente
        Return s.buscarultimo(Me)
    End Function
#End Region


    Public Overrides Function ToString() As String
        Return m_nombre & " - " & m_id
    End Function
    Public Function listar() As ArrayList
        Dim p As New pCliente
        Return p.listar
    End Function
    Public Function listarxid() As ArrayList
        Dim p As New pCliente
        Return p.listarxid
    End Function
    Public Function listartodos() As ArrayList
        Dim p As New pCliente
        Return p.listartodos
    End Function
    Public Function listarsocios() As ArrayList
        Dim p As New pCliente
        Return p.listarsocios
    End Function
    Public Function listarempresa() As ArrayList
        Dim p As New pCliente
        Return p.listarempresa
    End Function
    Public Function listarxtecnico(ByVal id As Long) As ArrayList
        Dim p As New pCliente
        Return p.listarxtecnico(id)
    End Function
    Public Function listarxdepartamento(ByVal iddepto As Integer) As ArrayList
        Dim p As New pCliente
        Return p.listarxdepartamento(iddepto)
    End Function
    Public Function actualizardireccion(ByVal idcliente As Integer, ByVal direnvio As String, ByVal usuario As dUsuario) As Boolean
        Dim p As New pCliente
        Return p.actualizardireccion(idcliente, direnvio, usuario)
    End Function
  
    Public Function actualizartecnico1(ByVal idcliente As Integer, ByVal tec As Long, ByVal usuario As dUsuario) As Boolean
        Dim p As New pCliente
        Return p.actualizartecnico1(idcliente, tec, usuario)
    End Function
    Public Function actualizartecnico2(ByVal idcliente As Integer, ByVal tec2 As Long, ByVal usuario As dUsuario) As Boolean
        Dim p As New pCliente
        Return p.actualizartecnico2(idcliente, tec2, usuario)
    End Function
    Public Function actualizaragencia(ByVal idcliente As Integer, ByVal age As Integer, ByVal usuario As dUsuario) As Boolean
        Dim p As New pCliente
        Return p.actualizaragencia(idcliente, age, usuario)
    End Function
    'Public Function actualizarmail(ByVal idcliente As Integer, ByVal mail As String, ByVal usuario As dUsuario) As Boolean
    '    Dim p As New pCliente
    '    Return p.actualizarmail(idcliente, mail, usuario)
    'End Function
    Public Function actualizardicose(ByVal idcliente As Integer, ByVal dicose As String, ByVal usuario As dUsuario) As Boolean
        Dim p As New pCliente
        Return p.actualizardicose(idcliente, dicose, usuario)
    End Function
    Public Function actualizarTecnicoSueloNutri(ByVal idcliente As Integer, ByVal tecnicoSueloNutri As Integer) As Boolean
        Dim p As New pCliente
        Return p.actualizarTecnicoSueloNutri(idcliente, tecnicoSueloNutri)
    End Function
End Class
