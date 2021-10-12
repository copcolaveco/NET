<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEnvioCajas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEnvioCajas))
        Me.TextFrascos = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextGradilla2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextGradilla1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextProductor = New System.Windows.Forms.TextBox()
        Me.TextCaja = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextIdProductor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboAgencia = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextEnvio = New System.Windows.Forms.TextBox()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListCajas = New System.Windows.Forms.ListBox()
        Me.ButtonBorrar = New System.Windows.Forms.Button()
        Me.ListPedidos = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextDireccion = New System.Windows.Forms.TextBox()
        Me.TextTelefono = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateFechaPosEnvio = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextOtros = New System.Windows.Forms.TextBox()
        Me.TextEsteriles = New System.Windows.Forms.TextBox()
        Me.TextSangre = New System.Windows.Forms.TextBox()
        Me.TextAgua = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextRC_compos = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DateFechaEnvio = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ButtonEnvio = New System.Windows.Forms.Button()
        Me.CheckBoxEnviado = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextObservacionesE = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextIdEnvio = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.TextGradilla3 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.ComboResponsable = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TextUsuarioCreador = New System.Windows.Forms.TextBox()
        Me.ComboCajas = New System.Windows.Forms.ComboBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonListarPedidos = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ActualizarCajasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizarCajasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarPedidosAutomáticosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckPendiente = New System.Windows.Forms.CheckBox()
        Me.ComboProlesa = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextFrascos
        '
        Me.TextFrascos.Location = New System.Drawing.Point(819, 79)
        Me.TextFrascos.Name = "TextFrascos"
        Me.TextFrascos.Size = New System.Drawing.Size(41, 20)
        Me.TextFrascos.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(816, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Frascos"
        '
        'TextGradilla2
        '
        Me.TextGradilla2.Location = New System.Drawing.Point(719, 79)
        Me.TextGradilla2.Name = "TextGradilla2"
        Me.TextGradilla2.Size = New System.Drawing.Size(44, 20)
        Me.TextGradilla2.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(716, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Grad.2"
        '
        'TextGradilla1
        '
        Me.TextGradilla1.Location = New System.Drawing.Point(669, 79)
        Me.TextGradilla1.Name = "TextGradilla1"
        Me.TextGradilla1.Size = New System.Drawing.Size(44, 20)
        Me.TextGradilla1.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(666, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Grad.1"
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(385, 110)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.ReadOnly = True
        Me.TextProductor.Size = New System.Drawing.Size(176, 20)
        Me.TextProductor.TabIndex = 23
        '
        'TextCaja
        '
        Me.TextCaja.Location = New System.Drawing.Point(886, 27)
        Me.TextCaja.Name = "TextCaja"
        Me.TextCaja.Size = New System.Drawing.Size(85, 20)
        Me.TextCaja.TabIndex = 5
        Me.TextCaja.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(257, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Productor"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(570, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Nº Caja"
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(326, 83)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(257, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Fecha"
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(326, 110)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.ReadOnly = True
        Me.TextIdProductor.Size = New System.Drawing.Size(53, 20)
        Me.TextIdProductor.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(570, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Agencia"
        '
        'ComboAgencia
        '
        Me.ComboAgencia.FormattingEnabled = True
        Me.ComboAgencia.Location = New System.Drawing.Point(622, 27)
        Me.ComboAgencia.Name = "ComboAgencia"
        Me.ComboAgencia.Size = New System.Drawing.Size(163, 21)
        Me.ComboAgencia.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(863, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Envío Nº"
        '
        'TextEnvio
        '
        Me.TextEnvio.Location = New System.Drawing.Point(866, 78)
        Me.TextEnvio.Name = "TextEnvio"
        Me.TextEnvio.Size = New System.Drawing.Size(105, 20)
        Me.TextEnvio.TabIndex = 10
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(327, 54)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(75, 20)
        Me.TextId.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(257, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Id"
        '
        'ListCajas
        '
        Me.ListCajas.FormattingEnabled = True
        Me.ListCajas.Location = New System.Drawing.Point(573, 144)
        Me.ListCajas.Name = "ListCajas"
        Me.ListCajas.Size = New System.Drawing.Size(351, 199)
        Me.ListCajas.TabIndex = 41
        '
        'ButtonBorrar
        '
        Me.ButtonBorrar.Location = New System.Drawing.Point(915, 104)
        Me.ButtonBorrar.Name = "ButtonBorrar"
        Me.ButtonBorrar.Size = New System.Drawing.Size(56, 20)
        Me.ButtonBorrar.TabIndex = 42
        Me.ButtonBorrar.Text = "Borrar"
        Me.ButtonBorrar.UseVisualStyleBackColor = True
        '
        'ListPedidos
        '
        Me.ListPedidos.BackColor = System.Drawing.SystemColors.Info
        Me.ListPedidos.FormattingEnabled = True
        Me.ListPedidos.Location = New System.Drawing.Point(11, 54)
        Me.ListPedidos.Name = "ListPedidos"
        Me.ListPedidos.Size = New System.Drawing.Size(224, 303)
        Me.ListPedidos.TabIndex = 43
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Pedidos"
        '
        'TextDireccion
        '
        Me.TextDireccion.Location = New System.Drawing.Point(326, 136)
        Me.TextDireccion.Name = "TextDireccion"
        Me.TextDireccion.ReadOnly = True
        Me.TextDireccion.Size = New System.Drawing.Size(235, 20)
        Me.TextDireccion.TabIndex = 45
        '
        'TextTelefono
        '
        Me.TextTelefono.Location = New System.Drawing.Point(326, 190)
        Me.TextTelefono.Name = "TextTelefono"
        Me.TextTelefono.ReadOnly = True
        Me.TextTelefono.Size = New System.Drawing.Size(235, 20)
        Me.TextTelefono.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(257, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Dirección"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(257, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Teléfono"
        '
        'DateFechaPosEnvio
        '
        Me.DateFechaPosEnvio.Enabled = False
        Me.DateFechaPosEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaPosEnvio.Location = New System.Drawing.Point(443, 83)
        Me.DateFechaPosEnvio.Name = "DateFechaPosEnvio"
        Me.DateFechaPosEnvio.Size = New System.Drawing.Size(100, 20)
        Me.DateFechaPosEnvio.TabIndex = 49
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(440, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 13)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Fecha posible envío"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TextOtros)
        Me.GroupBox1.Controls.Add(Me.TextEsteriles)
        Me.GroupBox1.Controls.Add(Me.TextSangre)
        Me.GroupBox1.Controls.Add(Me.TextAgua)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.TextRC_compos)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(260, 220)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(301, 272)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Frascos"
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(9, 172)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.ReadOnly = True
        Me.TextObservaciones.Size = New System.Drawing.Size(286, 91)
        Me.TextObservaciones.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 156)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Observaciones"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 130)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 13)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Otros"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Estériles"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 78)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Sangre"
        '
        'TextOtros
        '
        Me.TextOtros.Location = New System.Drawing.Point(78, 123)
        Me.TextOtros.Name = "TextOtros"
        Me.TextOtros.ReadOnly = True
        Me.TextOtros.Size = New System.Drawing.Size(78, 20)
        Me.TextOtros.TabIndex = 10
        '
        'TextEsteriles
        '
        Me.TextEsteriles.Location = New System.Drawing.Point(78, 97)
        Me.TextEsteriles.Name = "TextEsteriles"
        Me.TextEsteriles.ReadOnly = True
        Me.TextEsteriles.Size = New System.Drawing.Size(78, 20)
        Me.TextEsteriles.TabIndex = 9
        '
        'TextSangre
        '
        Me.TextSangre.Location = New System.Drawing.Point(78, 71)
        Me.TextSangre.Name = "TextSangre"
        Me.TextSangre.ReadOnly = True
        Me.TextSangre.Size = New System.Drawing.Size(78, 20)
        Me.TextSangre.TabIndex = 8
        '
        'TextAgua
        '
        Me.TextAgua.Location = New System.Drawing.Point(78, 45)
        Me.TextAgua.Name = "TextAgua"
        Me.TextAgua.ReadOnly = True
        Me.TextAgua.Size = New System.Drawing.Size(78, 20)
        Me.TextAgua.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 52)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Agua"
        '
        'TextRC_compos
        '
        Me.TextRC_compos.Location = New System.Drawing.Point(78, 19)
        Me.TextRC_compos.Name = "TextRC_compos"
        Me.TextRC_compos.ReadOnly = True
        Me.TextRC_compos.Size = New System.Drawing.Size(78, 20)
        Me.TextRC_compos.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "RC Compos."
        '
        'DateFechaEnvio
        '
        Me.DateFechaEnvio.Enabled = False
        Me.DateFechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaEnvio.Location = New System.Drawing.Point(659, 430)
        Me.DateFechaEnvio.Name = "DateFechaEnvio"
        Me.DateFechaEnvio.Size = New System.Drawing.Size(100, 20)
        Me.DateFechaEnvio.TabIndex = 53
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(570, 434)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 54
        Me.Label21.Text = "Fecha de envío"
        '
        'ButtonEnvio
        '
        Me.ButtonEnvio.Location = New System.Drawing.Point(767, 427)
        Me.ButtonEnvio.Name = "ButtonEnvio"
        Me.ButtonEnvio.Size = New System.Drawing.Size(157, 54)
        Me.ButtonEnvio.TabIndex = 55
        Me.ButtonEnvio.Text = "Enviar"
        Me.ButtonEnvio.UseVisualStyleBackColor = True
        '
        'CheckBoxEnviado
        '
        Me.CheckBoxEnviado.AutoSize = True
        Me.CheckBoxEnviado.Location = New System.Drawing.Point(573, 466)
        Me.CheckBoxEnviado.Name = "CheckBoxEnviado"
        Me.CheckBoxEnviado.Size = New System.Drawing.Size(95, 17)
        Me.CheckBoxEnviado.TabIndex = 56
        Me.CheckBoxEnviado.Text = "Enviado / Mail"
        Me.CheckBoxEnviado.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(575, 355)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 13)
        Me.Label22.TabIndex = 57
        Me.Label22.Text = "Observaciones"
        '
        'TextObservacionesE
        '
        Me.TextObservacionesE.Location = New System.Drawing.Point(659, 355)
        Me.TextObservacionesE.Multiline = True
        Me.TextObservacionesE.Name = "TextObservacionesE"
        Me.TextObservacionesE.Size = New System.Drawing.Size(267, 66)
        Me.TextObservacionesE.TabIndex = 58
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(575, 128)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(28, 13)
        Me.Label20.TabIndex = 60
        Me.Label20.Text = "Caja"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(619, 128)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 13)
        Me.Label23.TabIndex = 61
        Me.Label23.Text = "Grad.1"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(669, 128)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 13)
        Me.Label24.TabIndex = 62
        Me.Label24.Text = "Grad.2"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(791, 128)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 13)
        Me.Label25.TabIndex = 63
        Me.Label25.Text = "Frascos"
        '
        'TextIdEnvio
        '
        Me.TextIdEnvio.Location = New System.Drawing.Point(818, 104)
        Me.TextIdEnvio.Name = "TextIdEnvio"
        Me.TextIdEnvio.Size = New System.Drawing.Size(44, 20)
        Me.TextIdEnvio.TabIndex = 64
        Me.TextIdEnvio.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(867, 128)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(36, 13)
        Me.Label26.TabIndex = 65
        Me.Label26.Text = "Envío"
        '
        'Timer1
        '
        Me.Timer1.Interval = 300000
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(876, 493)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(95, 23)
        Me.ButtonEliminar.TabIndex = 66
        Me.ButtonEliminar.Text = "Eliminar pedido"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'TextGradilla3
        '
        Me.TextGradilla3.Location = New System.Drawing.Point(769, 79)
        Me.TextGradilla3.Name = "TextGradilla3"
        Me.TextGradilla3.Size = New System.Drawing.Size(44, 20)
        Me.TextGradilla3.TabIndex = 8
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(767, 61)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 67
        Me.Label27.Text = "Grad.3"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(727, 128)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 68
        Me.Label28.Text = "Grad.3"
        '
        'ComboResponsable
        '
        Me.ComboResponsable.FormattingEnabled = True
        Me.ComboResponsable.Location = New System.Drawing.Point(645, 495)
        Me.ComboResponsable.Name = "ComboResponsable"
        Me.ComboResponsable.Size = New System.Drawing.Size(217, 21)
        Me.ComboResponsable.TabIndex = 70
        Me.ComboResponsable.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(570, 498)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(69, 13)
        Me.Label29.TabIndex = 71
        Me.Label29.Text = "Responsable"
        Me.Label29.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(257, 30)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(99, 13)
        Me.Label30.TabIndex = 72
        Me.Label30.Text = "Pedido tomado por:"
        '
        'TextUsuarioCreador
        '
        Me.TextUsuarioCreador.Location = New System.Drawing.Point(362, 27)
        Me.TextUsuarioCreador.Name = "TextUsuarioCreador"
        Me.TextUsuarioCreador.ReadOnly = True
        Me.TextUsuarioCreador.Size = New System.Drawing.Size(199, 20)
        Me.TextUsuarioCreador.TabIndex = 73
        '
        'ComboCajas
        '
        Me.ComboCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCajas.FormattingEnabled = True
        Me.ComboCajas.Location = New System.Drawing.Point(573, 78)
        Me.ComboCajas.Name = "ComboCajas"
        Me.ComboCajas.Size = New System.Drawing.Size(90, 21)
        Me.ComboCajas.TabIndex = 74
        '
        'Timer2
        '
        Me.Timer2.Interval = 20000
        '
        'ButtonListarPedidos
        '
        Me.ButtonListarPedidos.Location = New System.Drawing.Point(138, 27)
        Me.ButtonListarPedidos.Name = "ButtonListarPedidos"
        Me.ButtonListarPedidos.Size = New System.Drawing.Size(97, 23)
        Me.ButtonListarPedidos.TabIndex = 75
        Me.ButtonListarPedidos.Text = "Listar pedidos"
        Me.ButtonListarPedidos.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarCajasToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(983, 24)
        Me.MenuStrip1.TabIndex = 76
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ActualizarCajasToolStripMenuItem
        '
        Me.ActualizarCajasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarCajasToolStripMenuItem1, Me.CargarPedidosAutomáticosToolStripMenuItem})
        Me.ActualizarCajasToolStripMenuItem.Name = "ActualizarCajasToolStripMenuItem"
        Me.ActualizarCajasToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.ActualizarCajasToolStripMenuItem.Text = "Herramientas"
        '
        'ActualizarCajasToolStripMenuItem1
        '
        Me.ActualizarCajasToolStripMenuItem1.Name = "ActualizarCajasToolStripMenuItem1"
        Me.ActualizarCajasToolStripMenuItem1.Size = New System.Drawing.Size(223, 22)
        Me.ActualizarCajasToolStripMenuItem1.Text = "Actualizar cajas"
        '
        'CargarPedidosAutomáticosToolStripMenuItem
        '
        Me.CargarPedidosAutomáticosToolStripMenuItem.Name = "CargarPedidosAutomáticosToolStripMenuItem"
        Me.CargarPedidosAutomáticosToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.CargarPedidosAutomáticosToolStripMenuItem.Text = "Cargar pedidos automáticos"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Cantidad})
        Me.DataGridView1.Location = New System.Drawing.Point(11, 361)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(225, 131)
        Me.DataGridView1.TabIndex = 80
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "RC Compos."
        Me.Cantidad.Name = "Cantidad"
        '
        'CheckPendiente
        '
        Me.CheckPendiente.AutoSize = True
        Me.CheckPendiente.Location = New System.Drawing.Point(260, 499)
        Me.CheckPendiente.Name = "CheckPendiente"
        Me.CheckPendiente.Size = New System.Drawing.Size(74, 17)
        Me.CheckPendiente.TabIndex = 81
        Me.CheckPendiente.Text = "Pendiente"
        Me.CheckPendiente.UseVisualStyleBackColor = True
        '
        'ComboProlesa
        '
        Me.ComboProlesa.BackColor = System.Drawing.SystemColors.MenuBar
        Me.ComboProlesa.Enabled = False
        Me.ComboProlesa.FormattingEnabled = True
        Me.ComboProlesa.Location = New System.Drawing.Point(326, 162)
        Me.ComboProlesa.Name = "ComboProlesa"
        Me.ComboProlesa.Size = New System.Drawing.Size(235, 21)
        Me.ComboProlesa.TabIndex = 82
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(257, 165)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(67, 13)
        Me.Label31.TabIndex = 83
        Me.Label31.Text = "Suc. Prolesa"
        '
        'FormEnvioCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 532)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.ComboProlesa)
        Me.Controls.Add(Me.CheckPendiente)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonListarPedidos)
        Me.Controls.Add(Me.ComboCajas)
        Me.Controls.Add(Me.TextUsuarioCreador)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.ComboResponsable)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TextGradilla3)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.DateFechaPosEnvio)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.TextIdEnvio)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TextObservacionesE)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.CheckBoxEnviado)
        Me.Controls.Add(Me.ButtonEnvio)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.DateFechaEnvio)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextTelefono)
        Me.Controls.Add(Me.TextDireccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ListPedidos)
        Me.Controls.Add(Me.ButtonBorrar)
        Me.Controls.Add(Me.ListCajas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.TextEnvio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboAgencia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFrascos)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextGradilla2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextGradilla1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.TextCaja)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormEnvioCajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envíos de materiales RG.ADM.13 v04"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextFrascos As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextGradilla2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextGradilla1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents TextCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextEnvio As System.Windows.Forms.TextBox
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListCajas As System.Windows.Forms.ListBox
    Friend WithEvents ButtonBorrar As System.Windows.Forms.Button
    Friend WithEvents ListPedidos As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TextTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateFechaPosEnvio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextOtros As System.Windows.Forms.TextBox
    Friend WithEvents TextEsteriles As System.Windows.Forms.TextBox
    Friend WithEvents TextSangre As System.Windows.Forms.TextBox
    Friend WithEvents TextAgua As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextRC_compos As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DateFechaEnvio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ButtonEnvio As System.Windows.Forms.Button
    Friend WithEvents CheckBoxEnviado As System.Windows.Forms.CheckBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextObservacionesE As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextIdEnvio As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents TextGradilla3 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ComboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TextUsuarioCreador As System.Windows.Forms.TextBox
    Friend WithEvents ComboCajas As System.Windows.Forms.ComboBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ButtonListarPedidos As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ActualizarCajasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckPendiente As System.Windows.Forms.CheckBox
    Friend WithEvents ActualizarCajasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargarPedidosAutomáticosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboProlesa As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label

End Class
