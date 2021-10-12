<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitud
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DateMuestreo = New System.Windows.Forms.DateTimePicker()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.CheckMuestreo = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextGradilla3 = New System.Windows.Forms.TextBox()
        Me.TextGradilla2 = New System.Windows.Forms.TextBox()
        Me.TextCaja = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextGradilla1 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextObsInternas = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboSubInforme = New System.Windows.Forms.ComboBox()
        Me.CheckFrascos = New System.Windows.Forms.CheckBox()
        Me.PictureImagen = New System.Windows.Forms.PictureBox()
        Me.ButtonImagen = New System.Windows.Forms.Button()
        Me.ComboCajas = New System.Windows.Forms.ComboBox()
        Me.ButtonAgregarCaja = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextKmts = New System.Windows.Forms.TextBox()
        Me.CheckPago = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextOtros = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextDicose = New System.Windows.Forms.TextBox()
        Me.ButtonBuscar = New System.Windows.Forms.Button()
        Me.CheckCajas = New System.Windows.Forms.CheckBox()
        Me.ComboTecnico = New System.Windows.Forms.ComboBox()
        Me.TextIdSC = New System.Windows.Forms.TextBox()
        Me.TextIdEnvio = New System.Windows.Forms.TextBox()
        Me.ComboTipoInforme = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboAgencia = New System.Windows.Forms.ComboBox()
        Me.TextRemito = New System.Windows.Forms.TextBox()
        Me.DateFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ButtonEliminarCaja = New System.Windows.Forms.Button()
        Me.TextNMuestras = New System.Windows.Forms.TextBox()
        Me.TextProductor = New System.Windows.Forms.TextBox()
        Me.ListCajas = New System.Windows.Forms.ListBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextTemperatura = New System.Windows.Forms.TextBox()
        Me.TextFrascos = New System.Windows.Forms.TextBox()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CheckSinConservante = New System.Windows.Forms.CheckBox()
        Me.ComboMuestra = New System.Windows.Forms.ComboBox()
        Me.ButtonBuscarProductor = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckSinSolicitud = New System.Windows.Forms.CheckBox()
        Me.CheckDerramadas = New System.Windows.Forms.CheckBox()
        Me.TextIdProductor = New System.Windows.Forms.TextBox()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.CheckDesvio = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ButtonAnalisisTercerizados = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muestra2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analisis2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quitar2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ButtonAgregar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextMuestras = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analisis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.X = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(964, 564)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DateMuestreo)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.CheckMuestreo)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.TextGradilla3)
        Me.TabPage1.Controls.Add(Me.TextGradilla2)
        Me.TabPage1.Controls.Add(Me.TextCaja)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.TextGradilla1)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.TextObsInternas)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.ComboSubInforme)
        Me.TabPage1.Controls.Add(Me.CheckFrascos)
        Me.TabPage1.Controls.Add(Me.PictureImagen)
        Me.TabPage1.Controls.Add(Me.ButtonImagen)
        Me.TabPage1.Controls.Add(Me.ComboCajas)
        Me.TabPage1.Controls.Add(Me.ButtonAgregarCaja)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.TextKmts)
        Me.TabPage1.Controls.Add(Me.CheckPago)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.TextOtros)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.TextDicose)
        Me.TabPage1.Controls.Add(Me.ButtonBuscar)
        Me.TabPage1.Controls.Add(Me.CheckCajas)
        Me.TabPage1.Controls.Add(Me.ComboTecnico)
        Me.TabPage1.Controls.Add(Me.TextIdSC)
        Me.TabPage1.Controls.Add(Me.TextIdEnvio)
        Me.TabPage1.Controls.Add(Me.ComboTipoInforme)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.TextId)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.ComboAgencia)
        Me.TabPage1.Controls.Add(Me.TextRemito)
        Me.TabPage1.Controls.Add(Me.DateFechaIngreso)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.ButtonEliminarCaja)
        Me.TabPage1.Controls.Add(Me.TextNMuestras)
        Me.TabPage1.Controls.Add(Me.TextProductor)
        Me.TabPage1.Controls.Add(Me.ListCajas)
        Me.TabPage1.Controls.Add(Me.ButtonGuardar)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.TextTemperatura)
        Me.TabPage1.Controls.Add(Me.TextFrascos)
        Me.TabPage1.Controls.Add(Me.ButtonNuevo)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.CheckSinConservante)
        Me.TabPage1.Controls.Add(Me.ComboMuestra)
        Me.TabPage1.Controls.Add(Me.ButtonBuscarProductor)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.CheckSinSolicitud)
        Me.TabPage1.Controls.Add(Me.CheckDerramadas)
        Me.TabPage1.Controls.Add(Me.TextIdProductor)
        Me.TabPage1.Controls.Add(Me.TextObservaciones)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label24)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.CheckDesvio)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(956, 538)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Ingreso"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DateMuestreo
        '
        Me.DateMuestreo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateMuestreo.Location = New System.Drawing.Point(370, 288)
        Me.DateMuestreo.Name = "DateMuestreo"
        Me.DateMuestreo.Size = New System.Drawing.Size(98, 20)
        Me.DateMuestreo.TabIndex = 156
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(374, 272)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(83, 13)
        Me.Label27.TabIndex = 155
        Me.Label27.Text = "Fecha muestreo"
        '
        'CheckMuestreo
        '
        Me.CheckMuestreo.AutoSize = True
        Me.CheckMuestreo.Location = New System.Drawing.Point(211, 264)
        Me.CheckMuestreo.Name = "CheckMuestreo"
        Me.CheckMuestreo.Size = New System.Drawing.Size(70, 17)
        Me.CheckMuestreo.TabIndex = 154
        Me.CheckMuestreo.Text = "Muestreo"
        Me.CheckMuestreo.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(740, 496)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 153
        Me.Label20.Text = "Grad.3"
        Me.Label20.Visible = False
        '
        'TextGradilla3
        '
        Me.TextGradilla3.Location = New System.Drawing.Point(741, 512)
        Me.TextGradilla3.Name = "TextGradilla3"
        Me.TextGradilla3.Size = New System.Drawing.Size(43, 20)
        Me.TextGradilla3.TabIndex = 152
        Me.TextGradilla3.Visible = False
        '
        'TextGradilla2
        '
        Me.TextGradilla2.Location = New System.Drawing.Point(692, 512)
        Me.TextGradilla2.Name = "TextGradilla2"
        Me.TextGradilla2.Size = New System.Drawing.Size(43, 20)
        Me.TextGradilla2.TabIndex = 149
        Me.TextGradilla2.Visible = False
        '
        'TextCaja
        '
        Me.TextCaja.Location = New System.Drawing.Point(535, 512)
        Me.TextCaja.Name = "TextCaja"
        Me.TextCaja.Size = New System.Drawing.Size(102, 20)
        Me.TextCaja.TabIndex = 147
        Me.TextCaja.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(645, 496)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 13)
        Me.Label21.TabIndex = 150
        Me.Label21.Text = "Grad.1"
        Me.Label21.Visible = False
        '
        'TextGradilla1
        '
        Me.TextGradilla1.Location = New System.Drawing.Point(643, 512)
        Me.TextGradilla1.Name = "TextGradilla1"
        Me.TextGradilla1.Size = New System.Drawing.Size(43, 20)
        Me.TextGradilla1.TabIndex = 148
        Me.TextGradilla1.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(691, 496)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(39, 13)
        Me.Label26.TabIndex = 151
        Me.Label26.Text = "Grad.2"
        Me.Label26.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 182)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 146
        Me.Label13.Text = "internas"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 169)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 13)
        Me.Label14.TabIndex = 145
        Me.Label14.Text = "Observaciones"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 237)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 144
        Me.Label2.Text = "en informe"
        '
        'TextObsInternas
        '
        Me.TextObsInternas.BackColor = System.Drawing.SystemColors.Info
        Me.TextObsInternas.Location = New System.Drawing.Point(100, 157)
        Me.TextObsInternas.Multiline = True
        Me.TextObsInternas.Name = "TextObsInternas"
        Me.TextObsInternas.Size = New System.Drawing.Size(246, 44)
        Me.TextObsInternas.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(16, 133)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 13)
        Me.Label17.TabIndex = 142
        Me.Label17.Text = "Sub informe"
        '
        'ComboSubInforme
        '
        Me.ComboSubInforme.FormattingEnabled = True
        Me.ComboSubInforme.Location = New System.Drawing.Point(100, 130)
        Me.ComboSubInforme.Name = "ComboSubInforme"
        Me.ComboSubInforme.Size = New System.Drawing.Size(181, 21)
        Me.ComboSubInforme.TabIndex = 7
        '
        'CheckFrascos
        '
        Me.CheckFrascos.AutoSize = True
        Me.CheckFrascos.Location = New System.Drawing.Point(19, 419)
        Me.CheckFrascos.Name = "CheckFrascos"
        Me.CheckFrascos.Size = New System.Drawing.Size(190, 17)
        Me.CheckFrascos.TabIndex = 56
        Me.CheckFrascos.Text = "Frascos no enviados por Colaveco"
        Me.CheckFrascos.UseVisualStyleBackColor = True
        '
        'PictureImagen
        '
        Me.PictureImagen.Location = New System.Drawing.Point(490, 291)
        Me.PictureImagen.Name = "PictureImagen"
        Me.PictureImagen.Size = New System.Drawing.Size(293, 199)
        Me.PictureImagen.TabIndex = 141
        Me.PictureImagen.TabStop = False
        '
        'ButtonImagen
        '
        Me.ButtonImagen.Location = New System.Drawing.Point(490, 257)
        Me.ButtonImagen.Name = "ButtonImagen"
        Me.ButtonImagen.Size = New System.Drawing.Size(147, 23)
        Me.ButtonImagen.TabIndex = 140
        Me.ButtonImagen.Text = "Adjuntar imágen"
        Me.ButtonImagen.UseVisualStyleBackColor = True
        '
        'ComboCajas
        '
        Me.ComboCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCajas.FormattingEnabled = True
        Me.ComboCajas.Location = New System.Drawing.Point(490, 86)
        Me.ComboCajas.Name = "ComboCajas"
        Me.ComboCajas.Size = New System.Drawing.Size(123, 21)
        Me.ComboCajas.TabIndex = 139
        '
        'ButtonAgregarCaja
        '
        Me.ButtonAgregarCaja.Location = New System.Drawing.Point(619, 82)
        Me.ButtonAgregarCaja.Name = "ButtonAgregarCaja"
        Me.ButtonAgregarCaja.Size = New System.Drawing.Size(20, 23)
        Me.ButtonAgregarCaja.TabIndex = 138
        Me.ButtonAgregarCaja.Text = "+"
        Me.ButtonAgregarCaja.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(287, 264)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 137
        Me.Label10.Text = "Kmts"
        '
        'TextKmts
        '
        Me.TextKmts.Location = New System.Drawing.Point(319, 261)
        Me.TextKmts.Name = "TextKmts"
        Me.TextKmts.Size = New System.Drawing.Size(42, 20)
        Me.TextKmts.TabIndex = 91
        '
        'CheckPago
        '
        Me.CheckPago.AutoSize = True
        Me.CheckPago.Location = New System.Drawing.Point(19, 396)
        Me.CheckPago.Name = "CheckPago"
        Me.CheckPago.Size = New System.Drawing.Size(69, 17)
        Me.CheckPago.TabIndex = 136
        Me.CheckPago.Text = "Pago OK"
        Me.CheckPago.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(490, 211)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 13)
        Me.Label23.TabIndex = 135
        Me.Label23.Text = "Otros"
        '
        'TextOtros
        '
        Me.TextOtros.Location = New System.Drawing.Point(490, 225)
        Me.TextOtros.Name = "TextOtros"
        Me.TextOtros.Size = New System.Drawing.Size(296, 20)
        Me.TextOtros.TabIndex = 134
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 133
        Me.Label15.Text = "Dicose"
        '
        'TextDicose
        '
        Me.TextDicose.Location = New System.Drawing.Point(100, 77)
        Me.TextDicose.Name = "TextDicose"
        Me.TextDicose.Size = New System.Drawing.Size(181, 20)
        Me.TextDicose.TabIndex = 132
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(272, 467)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscar.TabIndex = 129
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'CheckCajas
        '
        Me.CheckCajas.AutoSize = True
        Me.CheckCajas.Location = New System.Drawing.Point(490, 49)
        Me.CheckCajas.Name = "CheckCajas"
        Me.CheckCajas.Size = New System.Drawing.Size(179, 17)
        Me.CheckCajas.TabIndex = 128
        Me.CheckCajas.Text = "Cajas no enviadas por Colaveco"
        Me.CheckCajas.UseVisualStyleBackColor = True
        '
        'ComboTecnico
        '
        Me.ComboTecnico.FormattingEnabled = True
        Me.ComboTecnico.Location = New System.Drawing.Point(101, 314)
        Me.ComboTecnico.Name = "ComboTecnico"
        Me.ComboTecnico.Size = New System.Drawing.Size(246, 21)
        Me.ComboTecnico.TabIndex = 94
        '
        'TextIdSC
        '
        Me.TextIdSC.Location = New System.Drawing.Point(745, 12)
        Me.TextIdSC.Name = "TextIdSC"
        Me.TextIdSC.ReadOnly = True
        Me.TextIdSC.Size = New System.Drawing.Size(38, 20)
        Me.TextIdSC.TabIndex = 126
        Me.TextIdSC.Visible = False
        '
        'TextIdEnvio
        '
        Me.TextIdEnvio.Location = New System.Drawing.Point(784, 12)
        Me.TextIdEnvio.Name = "TextIdEnvio"
        Me.TextIdEnvio.ReadOnly = True
        Me.TextIdEnvio.Size = New System.Drawing.Size(38, 20)
        Me.TextIdEnvio.TabIndex = 125
        Me.TextIdEnvio.Visible = False
        '
        'ComboTipoInforme
        '
        Me.ComboTipoInforme.FormattingEnabled = True
        Me.ComboTipoInforme.Location = New System.Drawing.Point(100, 103)
        Me.ComboTipoInforme.Name = "ComboTipoInforme"
        Me.ComboTipoInforme.Size = New System.Drawing.Size(181, 21)
        Me.ComboTipoInforme.TabIndex = 84
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(697, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 124
        Me.Label11.Text = "Remito"
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(100, 25)
        Me.TextId.Name = "TextId"
        Me.TextId.Size = New System.Drawing.Size(68, 20)
        Me.TextId.TabIndex = 79
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Cliente"
        '
        'ComboAgencia
        '
        Me.ComboAgencia.FormattingEnabled = True
        Me.ComboAgencia.Location = New System.Drawing.Point(539, 22)
        Me.ComboAgencia.Name = "ComboAgencia"
        Me.ComboAgencia.Size = New System.Drawing.Size(186, 21)
        Me.ComboAgencia.TabIndex = 105
        '
        'TextRemito
        '
        Me.TextRemito.Location = New System.Drawing.Point(694, 84)
        Me.TextRemito.Name = "TextRemito"
        Me.TextRemito.Size = New System.Drawing.Size(109, 20)
        Me.TextRemito.TabIndex = 113
        '
        'DateFechaIngreso
        '
        Me.DateFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaIngreso.Location = New System.Drawing.Point(278, 24)
        Me.DateFechaIngreso.Name = "DateFechaIngreso"
        Me.DateFechaIngreso.Size = New System.Drawing.Size(114, 20)
        Me.DateFechaIngreso.TabIndex = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(487, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "Agencia"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Tipo de informe"
        '
        'ButtonEliminarCaja
        '
        Me.ButtonEliminarCaja.Location = New System.Drawing.Point(731, 113)
        Me.ButtonEliminarCaja.Name = "ButtonEliminarCaja"
        Me.ButtonEliminarCaja.Size = New System.Drawing.Size(52, 23)
        Me.ButtonEliminarCaja.TabIndex = 117
        Me.ButtonEliminarCaja.Text = "Eliminar"
        Me.ButtonEliminarCaja.UseVisualStyleBackColor = True
        '
        'TextNMuestras
        '
        Me.TextNMuestras.Location = New System.Drawing.Point(101, 261)
        Me.TextNMuestras.Name = "TextNMuestras"
        Me.TextNMuestras.Size = New System.Drawing.Size(100, 20)
        Me.TextNMuestras.TabIndex = 89
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(198, 51)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(259, 20)
        Me.TextProductor.TabIndex = 83
        '
        'ListCajas
        '
        Me.ListCajas.BackColor = System.Drawing.SystemColors.Info
        Me.ListCajas.FormattingEnabled = True
        Me.ListCajas.Location = New System.Drawing.Point(490, 113)
        Me.ListCajas.Name = "ListCajas"
        Me.ListCajas.Size = New System.Drawing.Size(235, 95)
        Me.ListCajas.TabIndex = 122
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(191, 467)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 102
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(490, 73)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(43, 13)
        Me.Label22.TabIndex = 118
        Me.Label22.Text = "Nº Caja"
        '
        'TextTemperatura
        '
        Me.TextTemperatura.Location = New System.Drawing.Point(305, 287)
        Me.TextTemperatura.Name = "TextTemperatura"
        Me.TextTemperatura.Size = New System.Drawing.Size(56, 20)
        Me.TextTemperatura.TabIndex = 98
        '
        'TextFrascos
        '
        Me.TextFrascos.Location = New System.Drawing.Point(645, 84)
        Me.TextFrascos.Name = "TextFrascos"
        Me.TextFrascos.Size = New System.Drawing.Size(43, 20)
        Me.TextFrascos.TabIndex = 111
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(111, 467)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 103
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(642, 69)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 13)
        Me.Label19.TabIndex = 121
        Me.Label19.Text = "Frascos"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 319)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 116
        Me.Label18.Text = "Técnico"
        '
        'CheckSinConservante
        '
        Me.CheckSinConservante.AutoSize = True
        Me.CheckSinConservante.Location = New System.Drawing.Point(107, 350)
        Me.CheckSinConservante.Name = "CheckSinConservante"
        Me.CheckSinConservante.Size = New System.Drawing.Size(103, 17)
        Me.CheckSinConservante.TabIndex = 96
        Me.CheckSinConservante.Text = "Sin conservante"
        Me.CheckSinConservante.UseVisualStyleBackColor = True
        '
        'ComboMuestra
        '
        Me.ComboMuestra.FormattingEnabled = True
        Me.ComboMuestra.Location = New System.Drawing.Point(101, 287)
        Me.ComboMuestra.Name = "ComboMuestra"
        Me.ComboMuestra.Size = New System.Drawing.Size(121, 21)
        Me.ComboMuestra.TabIndex = 93
        '
        'ButtonBuscarProductor
        '
        Me.ButtonBuscarProductor.Location = New System.Drawing.Point(174, 48)
        Me.ButtonBuscarProductor.Name = "ButtonBuscarProductor"
        Me.ButtonBuscarProductor.Size = New System.Drawing.Size(18, 23)
        Me.ButtonBuscarProductor.TabIndex = 81
        Me.ButtonBuscarProductor.Text = "^"
        Me.ButtonBuscarProductor.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Ficha"
        '
        'CheckSinSolicitud
        '
        Me.CheckSinSolicitud.AutoSize = True
        Me.CheckSinSolicitud.Location = New System.Drawing.Point(19, 350)
        Me.CheckSinSolicitud.Name = "CheckSinSolicitud"
        Me.CheckSinSolicitud.Size = New System.Drawing.Size(82, 17)
        Me.CheckSinSolicitud.TabIndex = 95
        Me.CheckSinSolicitud.Text = "Sin solicitud"
        Me.CheckSinSolicitud.UseVisualStyleBackColor = True
        '
        'CheckDerramadas
        '
        Me.CheckDerramadas.AutoSize = True
        Me.CheckDerramadas.Location = New System.Drawing.Point(19, 373)
        Me.CheckDerramadas.Name = "CheckDerramadas"
        Me.CheckDerramadas.Size = New System.Drawing.Size(140, 17)
        Me.CheckDerramadas.TabIndex = 99
        Me.CheckDerramadas.Text = "Derramadas en el envío"
        Me.CheckDerramadas.UseVisualStyleBackColor = True
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(100, 51)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(68, 20)
        Me.TextIdProductor.TabIndex = 82
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(100, 211)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(246, 44)
        Me.TextObservaciones.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(183, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Fecha de ingreso"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(232, 291)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "Temperatura"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 290)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 92
        Me.Label16.Text = "Muestra de:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(16, 224)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(78, 13)
        Me.Label24.TabIndex = 114
        Me.Label24.Text = "Observaciones"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(16, 267)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(79, 13)
        Me.Label25.TabIndex = 90
        Me.Label25.Text = "Nº de muestras"
        '
        'CheckDesvio
        '
        Me.CheckDesvio.AutoSize = True
        Me.CheckDesvio.Location = New System.Drawing.Point(165, 373)
        Me.CheckDesvio.Name = "CheckDesvio"
        Me.CheckDesvio.Size = New System.Drawing.Size(224, 17)
        Me.CheckDesvio.TabIndex = 100
        Me.CheckDesvio.Text = "Desvío/Descarte autorizado por el cliente"
        Me.CheckDesvio.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ButtonAnalisisTercerizados)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Controls.Add(Me.ButtonAgregar)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.TextMuestras)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(956, 538)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Análisis"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ButtonAnalisisTercerizados
        '
        Me.ButtonAnalisisTercerizados.Location = New System.Drawing.Point(810, 33)
        Me.ButtonAnalisisTercerizados.Name = "ButtonAnalisisTercerizados"
        Me.ButtonAnalisisTercerizados.Size = New System.Drawing.Size(128, 23)
        Me.ButtonAnalisisTercerizados.TabIndex = 131
        Me.ButtonAnalisisTercerizados.Text = "Analisis tercerizados"
        Me.ButtonAnalisisTercerizados.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(863, 508)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 130
        Me.Button3.Text = "Guardar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(509, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Listado"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Muestra2, Me.Analisis2, Me.Quitar2})
        Me.DataGridView2.Location = New System.Drawing.Point(459, 62)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(479, 440)
        Me.DataGridView2.TabIndex = 5
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Visible = False
        '
        'Muestra2
        '
        Me.Muestra2.HeaderText = "Muestra"
        Me.Muestra2.Name = "Muestra2"
        '
        'Analisis2
        '
        Me.Analisis2.HeaderText = "Análisis"
        Me.Analisis2.Name = "Analisis2"
        Me.Analisis2.Width = 300
        '
        'Quitar2
        '
        Me.Quitar2.HeaderText = ""
        Me.Quitar2.Name = "Quitar2"
        Me.Quitar2.Text = "Quitar"
        Me.Quitar2.UseColumnTextForButtonValue = True
        Me.Quitar2.Width = 60
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Location = New System.Drawing.Point(378, 62)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAgregar.TabIndex = 4
        Me.ButtonAgregar.Text = "Agregar >>>"
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(240, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Análisis"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Muestra"
        '
        'TextMuestras
        '
        Me.TextMuestras.Location = New System.Drawing.Point(16, 36)
        Me.TextMuestras.Name = "TextMuestras"
        Me.TextMuestras.Size = New System.Drawing.Size(171, 20)
        Me.TextMuestras.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Analisis, Me.X})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 62)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(356, 440)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Analisis
        '
        Me.Analisis.HeaderText = "Análisis"
        Me.Analisis.Name = "Analisis"
        Me.Analisis.Width = 300
        '
        'X
        '
        Me.X.HeaderText = "X"
        Me.X.Name = "X"
        Me.X.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.X.Width = 40
        '
        'FormSolicitud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 590)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormSolicitud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextMuestras As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CheckFrascos As System.Windows.Forms.CheckBox
    Friend WithEvents PictureImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonImagen As System.Windows.Forms.Button
    Friend WithEvents ComboCajas As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonAgregarCaja As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextKmts As System.Windows.Forms.TextBox
    Friend WithEvents CheckPago As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextOtros As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextDicose As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents CheckCajas As System.Windows.Forms.CheckBox
    Friend WithEvents ComboTecnico As System.Windows.Forms.ComboBox
    Friend WithEvents TextIdSC As System.Windows.Forms.TextBox
    Friend WithEvents TextIdEnvio As System.Windows.Forms.TextBox
    Friend WithEvents ComboTipoInforme As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboAgencia As System.Windows.Forms.ComboBox
    Friend WithEvents TextRemito As System.Windows.Forms.TextBox
    Friend WithEvents DateFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ButtonEliminarCaja As System.Windows.Forms.Button
    Friend WithEvents TextNMuestras As System.Windows.Forms.TextBox
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents ListCajas As System.Windows.Forms.ListBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextTemperatura As System.Windows.Forms.TextBox
    Friend WithEvents TextFrascos As System.Windows.Forms.TextBox
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CheckSinConservante As System.Windows.Forms.CheckBox
    Friend WithEvents ComboMuestra As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonBuscarProductor As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckSinSolicitud As System.Windows.Forms.CheckBox
    Friend WithEvents CheckDerramadas As System.Windows.Forms.CheckBox
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents CheckDesvio As System.Windows.Forms.CheckBox
    Friend WithEvents ComboSubInforme As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextObsInternas As System.Windows.Forms.TextBox
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Muestra2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analisis2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quitar2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analisis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents X As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextGradilla3 As System.Windows.Forms.TextBox
    Friend WithEvents TextGradilla2 As System.Windows.Forms.TextBox
    Friend WithEvents TextCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextGradilla1 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ButtonAnalisisTercerizados As System.Windows.Forms.Button
    Friend WithEvents CheckMuestreo As System.Windows.Forms.CheckBox
    Friend WithEvents DateMuestreo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label27 As System.Windows.Forms.Label
End Class
