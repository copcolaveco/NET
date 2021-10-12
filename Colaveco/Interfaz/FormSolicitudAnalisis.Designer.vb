<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudAnalisis
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSolicitudAnalisis))
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.DateFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.TextNMuestras = New System.Windows.Forms.TextBox()
        Me.TextTemperatura = New System.Windows.Forms.TextBox()
        Me.ComboMuestra = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextRemito = New System.Windows.Forms.TextBox()
        Me.ButtonEliminarCaja = New System.Windows.Forms.Button()
        Me.ListCajas = New System.Windows.Forms.ListBox()
        Me.TextFrascos = New System.Windows.Forms.TextBox()
        Me.CheckDerramadas = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextGradilla2 = New System.Windows.Forms.TextBox()
        Me.CheckDesvio = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextGradilla1 = New System.Windows.Forms.TextBox()
        Me.CheckSinSolicitud = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CheckSinConservante = New System.Windows.Forms.CheckBox()
        Me.TextCaja = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.TextIdProductor = New System.Windows.Forms.TextBox()
        Me.ButtonBuscarProductor = New System.Windows.Forms.Button()
        Me.TextProductor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboTipoInforme = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboTipoFicha = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboSubInforme = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboTecnico = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheckFrascos = New System.Windows.Forms.CheckBox()
        Me.TextIdSM = New System.Windows.Forms.TextBox()
        Me.ButtonEliminarMuestra = New System.Windows.Forms.Button()
        Me.TextMuestras = New System.Windows.Forms.TextBox()
        Me.ListMuestras = New System.Windows.Forms.ListBox()
        Me.ComboAgencia = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextFactura = New System.Windows.Forms.TextBox()
        Me.TextIdFactura = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DateFechaEnvio = New System.Windows.Forms.DateTimePicker()
        Me.CheckEmail = New System.Windows.Forms.CheckBox()
        Me.CheckPersonal = New System.Windows.Forms.CheckBox()
        Me.CheckWeb = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextGradilla3 = New System.Windows.Forms.TextBox()
        Me.CheckCajas = New System.Windows.Forms.CheckBox()
        Me.TextIdSC = New System.Windows.Forms.TextBox()
        Me.TextIdEnvio = New System.Windows.Forms.TextBox()
        Me.ButtonBuscarProd = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextDicose = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextOtros = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CheckPago = New System.Windows.Forms.CheckBox()
        Me.TextKmts = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ButtonAgregarCaja = New System.Windows.Forms.Button()
        Me.ComboCajas = New System.Windows.Forms.ComboBox()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(96, 36)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(68, 20)
        Me.TextId.TabIndex = 1
        '
        'DateFechaIngreso
        '
        Me.DateFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaIngreso.Location = New System.Drawing.Point(274, 35)
        Me.DateFechaIngreso.Name = "DateFechaIngreso"
        Me.DateFechaIngreso.Size = New System.Drawing.Size(114, 20)
        Me.DateFechaIngreso.TabIndex = 2
        '
        'TextNMuestras
        '
        Me.TextNMuestras.Location = New System.Drawing.Point(96, 218)
        Me.TextNMuestras.Name = "TextNMuestras"
        Me.TextNMuestras.Size = New System.Drawing.Size(100, 20)
        Me.TextNMuestras.TabIndex = 8
        '
        'TextTemperatura
        '
        Me.TextTemperatura.Location = New System.Drawing.Point(285, 310)
        Me.TextTemperatura.Name = "TextTemperatura"
        Me.TextTemperatura.Size = New System.Drawing.Size(56, 20)
        Me.TextTemperatura.TabIndex = 13
        '
        'ComboMuestra
        '
        Me.ComboMuestra.FormattingEnabled = True
        Me.ComboMuestra.Location = New System.Drawing.Point(96, 244)
        Me.ComboMuestra.Name = "ComboMuestra"
        Me.ComboMuestra.Size = New System.Drawing.Size(121, 21)
        Me.ComboMuestra.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Ficha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(179, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Fecha de ingreso"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(694, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 52
        Me.Label11.Text = "Remito"
        '
        'TextRemito
        '
        Me.TextRemito.Location = New System.Drawing.Point(691, 76)
        Me.TextRemito.Name = "TextRemito"
        Me.TextRemito.Size = New System.Drawing.Size(109, 20)
        Me.TextRemito.TabIndex = 30
        '
        'ButtonEliminarCaja
        '
        Me.ButtonEliminarCaja.Location = New System.Drawing.Point(728, 105)
        Me.ButtonEliminarCaja.Name = "ButtonEliminarCaja"
        Me.ButtonEliminarCaja.Size = New System.Drawing.Size(52, 23)
        Me.ButtonEliminarCaja.TabIndex = 38
        Me.ButtonEliminarCaja.Text = "Eliminar"
        Me.ButtonEliminarCaja.UseVisualStyleBackColor = True
        '
        'ListCajas
        '
        Me.ListCajas.BackColor = System.Drawing.SystemColors.Info
        Me.ListCajas.FormattingEnabled = True
        Me.ListCajas.Location = New System.Drawing.Point(487, 105)
        Me.ListCajas.Name = "ListCajas"
        Me.ListCajas.Size = New System.Drawing.Size(235, 95)
        Me.ListCajas.TabIndex = 46
        '
        'TextFrascos
        '
        Me.TextFrascos.Location = New System.Drawing.Point(642, 76)
        Me.TextFrascos.Name = "TextFrascos"
        Me.TextFrascos.Size = New System.Drawing.Size(43, 20)
        Me.TextFrascos.TabIndex = 29
        '
        'CheckDerramadas
        '
        Me.CheckDerramadas.AutoSize = True
        Me.CheckDerramadas.Location = New System.Drawing.Point(15, 336)
        Me.CheckDerramadas.Name = "CheckDerramadas"
        Me.CheckDerramadas.Size = New System.Drawing.Size(140, 17)
        Me.CheckDerramadas.TabIndex = 14
        Me.CheckDerramadas.Text = "Derramadas en el envío"
        Me.CheckDerramadas.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(639, 61)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 13)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "Frascos"
        '
        'TextGradilla2
        '
        Me.TextGradilla2.Location = New System.Drawing.Point(558, 550)
        Me.TextGradilla2.Name = "TextGradilla2"
        Me.TextGradilla2.Size = New System.Drawing.Size(43, 20)
        Me.TextGradilla2.TabIndex = 28
        Me.TextGradilla2.Visible = False
        '
        'CheckDesvio
        '
        Me.CheckDesvio.AutoSize = True
        Me.CheckDesvio.Location = New System.Drawing.Point(103, 359)
        Me.CheckDesvio.Name = "CheckDesvio"
        Me.CheckDesvio.Size = New System.Drawing.Size(224, 17)
        Me.CheckDesvio.TabIndex = 15
        Me.CheckDesvio.Text = "Desvío/Descarte autorizado por el cliente"
        Me.CheckDesvio.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(557, 534)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "Grad.2"
        Me.Label20.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(212, 314)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Temperatura"
        '
        'TextGradilla1
        '
        Me.TextGradilla1.Location = New System.Drawing.Point(509, 550)
        Me.TextGradilla1.Name = "TextGradilla1"
        Me.TextGradilla1.Size = New System.Drawing.Size(43, 20)
        Me.TextGradilla1.TabIndex = 27
        Me.TextGradilla1.Visible = False
        '
        'CheckSinSolicitud
        '
        Me.CheckSinSolicitud.AutoSize = True
        Me.CheckSinSolicitud.Location = New System.Drawing.Point(15, 313)
        Me.CheckSinSolicitud.Name = "CheckSinSolicitud"
        Me.CheckSinSolicitud.Size = New System.Drawing.Size(82, 17)
        Me.CheckSinSolicitud.TabIndex = 12
        Me.CheckSinSolicitud.Text = "Sin solicitud"
        Me.CheckSinSolicitud.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(511, 534)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 13)
        Me.Label21.TabIndex = 43
        Me.Label21.Text = "Grad.1"
        Me.Label21.Visible = False
        '
        'CheckSinConservante
        '
        Me.CheckSinConservante.AutoSize = True
        Me.CheckSinConservante.Location = New System.Drawing.Point(103, 313)
        Me.CheckSinConservante.Name = "CheckSinConservante"
        Me.CheckSinConservante.Size = New System.Drawing.Size(103, 17)
        Me.CheckSinConservante.TabIndex = 12
        Me.CheckSinConservante.Text = "Sin conservante"
        Me.CheckSinConservante.UseVisualStyleBackColor = True
        '
        'TextCaja
        '
        Me.TextCaja.Location = New System.Drawing.Point(401, 550)
        Me.TextCaja.Name = "TextCaja"
        Me.TextCaja.Size = New System.Drawing.Size(102, 20)
        Me.TextCaja.TabIndex = 26
        Me.TextCaja.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(487, 65)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(43, 13)
        Me.Label22.TabIndex = 42
        Me.Label22.Text = "Nº Caja"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Nº de muestras"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 247)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Muestra de:"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(16, 537)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 19
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(96, 537)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 18
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(96, 62)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(68, 20)
        Me.TextIdProductor.TabIndex = 3
        '
        'ButtonBuscarProductor
        '
        Me.ButtonBuscarProductor.Location = New System.Drawing.Point(170, 59)
        Me.ButtonBuscarProductor.Name = "ButtonBuscarProductor"
        Me.ButtonBuscarProductor.Size = New System.Drawing.Size(18, 23)
        Me.ButtonBuscarProductor.TabIndex = 3
        Me.ButtonBuscarProductor.Text = "^"
        Me.ButtonBuscarProductor.UseVisualStyleBackColor = True
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(194, 62)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(259, 20)
        Me.TextProductor.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Cliente"
        '
        'ComboTipoInforme
        '
        Me.ComboTipoInforme.FormattingEnabled = True
        Me.ComboTipoInforme.Location = New System.Drawing.Point(96, 114)
        Me.ComboTipoInforme.Name = "ComboTipoInforme"
        Me.ComboTipoInforme.Size = New System.Drawing.Size(181, 21)
        Me.ComboTipoInforme.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Tipo de informe"
        '
        'ComboTipoFicha
        '
        Me.ComboTipoFicha.FormattingEnabled = True
        Me.ComboTipoFicha.Location = New System.Drawing.Point(96, 9)
        Me.ComboTipoFicha.Name = "ComboTipoFicha"
        Me.ComboTipoFicha.Size = New System.Drawing.Size(181, 21)
        Me.ComboTipoFicha.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Tipo de ficha"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(96, 168)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(246, 44)
        Me.TextObservaciones.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 181)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Observaciones"
        '
        'ComboSubInforme
        '
        Me.ComboSubInforme.FormattingEnabled = True
        Me.ComboSubInforme.Location = New System.Drawing.Point(96, 141)
        Me.ComboSubInforme.Name = "ComboSubInforme"
        Me.ComboSubInforme.Size = New System.Drawing.Size(181, 21)
        Me.ComboSubInforme.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 144)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Sub informe"
        '
        'ComboTecnico
        '
        Me.ComboTecnico.FormattingEnabled = True
        Me.ComboTecnico.Location = New System.Drawing.Point(96, 271)
        Me.ComboTecnico.Name = "ComboTecnico"
        Me.ComboTecnico.Size = New System.Drawing.Size(246, 21)
        Me.ComboTecnico.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 276)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Técnico"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckFrascos)
        Me.GroupBox4.Controls.Add(Me.TextIdSM)
        Me.GroupBox4.Controls.Add(Me.ButtonEliminarMuestra)
        Me.GroupBox4.Controls.Add(Me.TextMuestras)
        Me.GroupBox4.Controls.Add(Me.ListMuestras)
        Me.GroupBox4.Location = New System.Drawing.Point(373, 248)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(293, 276)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Muestras"
        '
        'CheckFrascos
        '
        Me.CheckFrascos.AutoSize = True
        Me.CheckFrascos.Location = New System.Drawing.Point(6, 19)
        Me.CheckFrascos.Name = "CheckFrascos"
        Me.CheckFrascos.Size = New System.Drawing.Size(190, 17)
        Me.CheckFrascos.TabIndex = 56
        Me.CheckFrascos.Text = "Frascos no enviados por Colaveco"
        Me.CheckFrascos.UseVisualStyleBackColor = True
        '
        'TextIdSM
        '
        Me.TextIdSM.Location = New System.Drawing.Point(234, 44)
        Me.TextIdSM.Name = "TextIdSM"
        Me.TextIdSM.ReadOnly = True
        Me.TextIdSM.Size = New System.Drawing.Size(44, 20)
        Me.TextIdSM.TabIndex = 55
        Me.TextIdSM.Visible = False
        '
        'ButtonEliminarMuestra
        '
        Me.ButtonEliminarMuestra.Location = New System.Drawing.Point(174, 44)
        Me.ButtonEliminarMuestra.Name = "ButtonEliminarMuestra"
        Me.ButtonEliminarMuestra.Size = New System.Drawing.Size(54, 23)
        Me.ButtonEliminarMuestra.TabIndex = 39
        Me.ButtonEliminarMuestra.Text = "Eliminar"
        Me.ButtonEliminarMuestra.UseVisualStyleBackColor = True
        '
        'TextMuestras
        '
        Me.TextMuestras.Location = New System.Drawing.Point(6, 47)
        Me.TextMuestras.Name = "TextMuestras"
        Me.TextMuestras.Size = New System.Drawing.Size(159, 20)
        Me.TextMuestras.TabIndex = 31
        '
        'ListMuestras
        '
        Me.ListMuestras.BackColor = System.Drawing.SystemColors.Info
        Me.ListMuestras.FormattingEnabled = True
        Me.ListMuestras.Location = New System.Drawing.Point(6, 73)
        Me.ListMuestras.Name = "ListMuestras"
        Me.ListMuestras.Size = New System.Drawing.Size(159, 199)
        Me.ListMuestras.TabIndex = 40
        '
        'ComboAgencia
        '
        Me.ComboAgencia.FormattingEnabled = True
        Me.ComboAgencia.Location = New System.Drawing.Point(536, 14)
        Me.ComboAgencia.Name = "ComboAgencia"
        Me.ComboAgencia.Size = New System.Drawing.Size(186, 21)
        Me.ComboAgencia.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(484, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Agencia"
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(177, 537)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscar.TabIndex = 55
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextFactura)
        Me.GroupBox2.Controls.Add(Me.TextIdFactura)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 409)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(307, 46)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Facturar a:"
        '
        'TextFactura
        '
        Me.TextFactura.Location = New System.Drawing.Point(104, 18)
        Me.TextFactura.Name = "TextFactura"
        Me.TextFactura.Size = New System.Drawing.Size(197, 20)
        Me.TextFactura.TabIndex = 56
        '
        'TextIdFactura
        '
        Me.TextIdFactura.Location = New System.Drawing.Point(6, 18)
        Me.TextIdFactura.Name = "TextIdFactura"
        Me.TextIdFactura.Size = New System.Drawing.Size(68, 20)
        Me.TextIdFactura.TabIndex = 16
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(80, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(18, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "^"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.DateFechaEnvio)
        Me.GroupBox3.Controls.Add(Me.CheckEmail)
        Me.GroupBox3.Controls.Add(Me.CheckPersonal)
        Me.GroupBox3.Controls.Add(Me.CheckWeb)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 470)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(314, 54)
        Me.GroupBox3.TabIndex = 54
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Enviádo"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(193, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Fecha de envío"
        '
        'DateFechaEnvio
        '
        Me.DateFechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaEnvio.Location = New System.Drawing.Point(196, 26)
        Me.DateFechaEnvio.Name = "DateFechaEnvio"
        Me.DateFechaEnvio.Size = New System.Drawing.Size(111, 20)
        Me.DateFechaEnvio.TabIndex = 24
        '
        'CheckEmail
        '
        Me.CheckEmail.AutoSize = True
        Me.CheckEmail.Location = New System.Drawing.Point(137, 29)
        Me.CheckEmail.Name = "CheckEmail"
        Me.CheckEmail.Size = New System.Drawing.Size(54, 17)
        Me.CheckEmail.TabIndex = 23
        Me.CheckEmail.Text = "E-mail"
        Me.CheckEmail.UseVisualStyleBackColor = True
        '
        'CheckPersonal
        '
        Me.CheckPersonal.AutoSize = True
        Me.CheckPersonal.Location = New System.Drawing.Point(64, 29)
        Me.CheckPersonal.Name = "CheckPersonal"
        Me.CheckPersonal.Size = New System.Drawing.Size(67, 17)
        Me.CheckPersonal.TabIndex = 22
        Me.CheckPersonal.Text = "Personal"
        Me.CheckPersonal.UseVisualStyleBackColor = True
        '
        'CheckWeb
        '
        Me.CheckWeb.AutoSize = True
        Me.CheckWeb.Location = New System.Drawing.Point(9, 29)
        Me.CheckWeb.Name = "CheckWeb"
        Me.CheckWeb.Size = New System.Drawing.Size(49, 17)
        Me.CheckWeb.TabIndex = 21
        Me.CheckWeb.Text = "Web"
        Me.CheckWeb.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(606, 534)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Grad.3"
        Me.Label14.Visible = False
        '
        'TextGradilla3
        '
        Me.TextGradilla3.Location = New System.Drawing.Point(607, 550)
        Me.TextGradilla3.Name = "TextGradilla3"
        Me.TextGradilla3.Size = New System.Drawing.Size(43, 20)
        Me.TextGradilla3.TabIndex = 57
        Me.TextGradilla3.Visible = False
        '
        'CheckCajas
        '
        Me.CheckCajas.AutoSize = True
        Me.CheckCajas.Location = New System.Drawing.Point(487, 41)
        Me.CheckCajas.Name = "CheckCajas"
        Me.CheckCajas.Size = New System.Drawing.Size(179, 17)
        Me.CheckCajas.TabIndex = 55
        Me.CheckCajas.Text = "Cajas no enviadas por Colaveco"
        Me.CheckCajas.UseVisualStyleBackColor = True
        '
        'TextIdSC
        '
        Me.TextIdSC.Location = New System.Drawing.Point(742, 4)
        Me.TextIdSC.Name = "TextIdSC"
        Me.TextIdSC.ReadOnly = True
        Me.TextIdSC.Size = New System.Drawing.Size(38, 20)
        Me.TextIdSC.TabIndex = 54
        Me.TextIdSC.Visible = False
        '
        'TextIdEnvio
        '
        Me.TextIdEnvio.Location = New System.Drawing.Point(781, 4)
        Me.TextIdEnvio.Name = "TextIdEnvio"
        Me.TextIdEnvio.ReadOnly = True
        Me.TextIdEnvio.Size = New System.Drawing.Size(38, 20)
        Me.TextIdEnvio.TabIndex = 53
        Me.TextIdEnvio.Visible = False
        '
        'ButtonBuscarProd
        '
        Me.ButtonBuscarProd.Location = New System.Drawing.Point(80, 16)
        Me.ButtonBuscarProd.Name = "ButtonBuscarProd"
        Me.ButtonBuscarProd.Size = New System.Drawing.Size(18, 23)
        Me.ButtonBuscarProd.TabIndex = 24
        Me.ButtonBuscarProd.Text = "^"
        Me.ButtonBuscarProd.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(193, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Fecha de envío"
        '
        'TextDicose
        '
        Me.TextDicose.Location = New System.Drawing.Point(96, 88)
        Me.TextDicose.Name = "TextDicose"
        Me.TextDicose.Size = New System.Drawing.Size(181, 20)
        Me.TextDicose.TabIndex = 59
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 91)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "Dicose"
        '
        'TextOtros
        '
        Me.TextOtros.Location = New System.Drawing.Point(487, 217)
        Me.TextOtros.Name = "TextOtros"
        Me.TextOtros.Size = New System.Drawing.Size(296, 20)
        Me.TextOtros.TabIndex = 61
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(487, 203)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 13)
        Me.Label23.TabIndex = 62
        Me.Label23.Text = "Otros"
        '
        'CheckPago
        '
        Me.CheckPago.AutoSize = True
        Me.CheckPago.Location = New System.Drawing.Point(15, 359)
        Me.CheckPago.Name = "CheckPago"
        Me.CheckPago.Size = New System.Drawing.Size(69, 17)
        Me.CheckPago.TabIndex = 63
        Me.CheckPago.Text = "Pago OK"
        Me.CheckPago.UseVisualStyleBackColor = True
        '
        'TextKmts
        '
        Me.TextKmts.Location = New System.Drawing.Point(300, 218)
        Me.TextKmts.Name = "TextKmts"
        Me.TextKmts.Size = New System.Drawing.Size(42, 20)
        Me.TextKmts.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(212, 221)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "Kmts (muestreo)"
        '
        'ButtonAgregarCaja
        '
        Me.ButtonAgregarCaja.Location = New System.Drawing.Point(616, 74)
        Me.ButtonAgregarCaja.Name = "ButtonAgregarCaja"
        Me.ButtonAgregarCaja.Size = New System.Drawing.Size(20, 23)
        Me.ButtonAgregarCaja.TabIndex = 66
        Me.ButtonAgregarCaja.Text = "+"
        Me.ButtonAgregarCaja.UseVisualStyleBackColor = True
        '
        'ComboCajas
        '
        Me.ComboCajas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboCajas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCajas.FormattingEnabled = True
        Me.ComboCajas.Location = New System.Drawing.Point(487, 78)
        Me.ComboCajas.Name = "ComboCajas"
        Me.ComboCajas.Size = New System.Drawing.Size(123, 21)
        Me.ComboCajas.TabIndex = 75
        '
        'FormSolicitudAnalisis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 582)
        Me.Controls.Add(Me.ComboCajas)
        Me.Controls.Add(Me.ButtonAgregarCaja)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextKmts)
        Me.Controls.Add(Me.CheckPago)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TextOtros)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TextDicose)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.TextGradilla3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CheckCajas)
        Me.Controls.Add(Me.ComboTecnico)
        Me.Controls.Add(Me.TextIdSC)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TextIdEnvio)
        Me.Controls.Add(Me.ComboTipoInforme)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboAgencia)
        Me.Controls.Add(Me.TextRemito)
        Me.Controls.Add(Me.DateFechaIngreso)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ButtonEliminarCaja)
        Me.Controls.Add(Me.TextNMuestras)
        Me.Controls.Add(Me.TextGradilla2)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.ListCajas)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TextTemperatura)
        Me.Controls.Add(Me.TextFrascos)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.TextCaja)
        Me.Controls.Add(Me.ComboTipoFicha)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.CheckSinConservante)
        Me.Controls.Add(Me.TextGradilla1)
        Me.Controls.Add(Me.ComboMuestra)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.ButtonBuscarProductor)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckSinSolicitud)
        Me.Controls.Add(Me.CheckDerramadas)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboSubInforme)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckDesvio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSolicitudAnalisis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud de análisis"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents DateFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextNMuestras As System.Windows.Forms.TextBox
    Friend WithEvents TextTemperatura As System.Windows.Forms.TextBox
    Friend WithEvents ComboMuestra As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CheckSinSolicitud As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSinConservante As System.Windows.Forms.CheckBox
    Friend WithEvents CheckDesvio As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents CheckDerramadas As System.Windows.Forms.CheckBox
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProductor As System.Windows.Forms.Button
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboTipoInforme As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboTipoFicha As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboSubInforme As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ComboTecnico As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonEliminarMuestra As System.Windows.Forms.Button
    Friend WithEvents TextMuestras As System.Windows.Forms.TextBox
    Friend WithEvents ListMuestras As System.Windows.Forms.ListBox
    Friend WithEvents ButtonEliminarCaja As System.Windows.Forms.Button
    Friend WithEvents ListCajas As System.Windows.Forms.ListBox
    Friend WithEvents TextFrascos As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextGradilla2 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextGradilla1 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextRemito As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DateFechaEnvio As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckEmail As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPersonal As System.Windows.Forms.CheckBox
    Friend WithEvents CheckWeb As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonBuscarProd As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextIdEnvio As System.Windows.Forms.TextBox
    Friend WithEvents TextIdSC As System.Windows.Forms.TextBox
    Friend WithEvents TextIdSM As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents TextFactura As System.Windows.Forms.TextBox
    Friend WithEvents TextIdFactura As System.Windows.Forms.TextBox
    Friend WithEvents CheckFrascos As System.Windows.Forms.CheckBox
    Friend WithEvents CheckCajas As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextGradilla3 As System.Windows.Forms.TextBox
    Friend WithEvents TextDicose As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextOtros As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CheckPago As System.Windows.Forms.CheckBox
    Friend WithEvents TextKmts As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ButtonAgregarCaja As System.Windows.Forms.Button
    Friend WithEvents ComboCajas As System.Windows.Forms.ComboBox
End Class
