<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUsuarios
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
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.TextNombre = New System.Windows.Forms.TextBox()
        Me.ComboSexo = New System.Windows.Forms.ComboBox()
        Me.TextCI = New System.Windows.Forms.TextBox()
        Me.ComboTipoUsuario = New System.Windows.Forms.ComboBox()
        Me.ComboSector = New System.Windows.Forms.ComboBox()
        Me.TextUsuario = New System.Windows.Forms.TextBox()
        Me.TextPassword = New System.Windows.Forms.TextBox()
        Me.CheckEliminado = New System.Windows.Forms.CheckBox()
        Me.TextFoto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCSalud = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CheckCambiar = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextEntra = New System.Windows.Forms.MaskedTextBox()
        Me.TextSale = New System.Windows.Forms.MaskedTextBox()
        Me.TextSale2 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntra2 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSale3 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntra3 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSale4 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntra4 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSale5 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntra5 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSale6 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntra6 = New System.Windows.Forms.MaskedTextBox()
        Me.RadioCorrido = New System.Windows.Forms.RadioButton()
        Me.RadioCortado = New System.Windows.Forms.RadioButton()
        Me.RadioRotativo = New System.Windows.Forms.RadioButton()
        Me.GroupCorrido = New System.Windows.Forms.GroupBox()
        Me.GroupCortado = New System.Windows.Forms.GroupBox()
        Me.TextSaleC = New System.Windows.Forms.MaskedTextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextEntraC = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntraC2 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSaleC2 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntraC3 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSaleC3 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntraC4 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSaleC4 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntraC5 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSaleC5 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntraC6 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSaleC6 = New System.Windows.Forms.MaskedTextBox()
        Me.GroupRotativo = New System.Windows.Forms.GroupBox()
        Me.TextSaleR = New System.Windows.Forms.MaskedTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextEntraR = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntraR2 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSaleR2 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntraR3 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSaleR3 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntraR4 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSaleR4 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntraR5 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSaleR5 = New System.Windows.Forms.MaskedTextBox()
        Me.TextEntraR6 = New System.Windows.Forms.MaskedTextBox()
        Me.TextSaleR6 = New System.Windows.Forms.MaskedTextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupCorrido.SuspendLayout()
        Me.GroupCortado.SuspendLayout()
        Me.GroupRotativo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(124, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(55, 20)
        Me.TextId.TabIndex = 0
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(124, 38)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(259, 20)
        Me.TextNombre.TabIndex = 1
        '
        'ComboSexo
        '
        Me.ComboSexo.FormattingEnabled = True
        Me.ComboSexo.Location = New System.Drawing.Point(124, 64)
        Me.ComboSexo.Name = "ComboSexo"
        Me.ComboSexo.Size = New System.Drawing.Size(55, 21)
        Me.ComboSexo.TabIndex = 2
        '
        'TextCI
        '
        Me.TextCI.Location = New System.Drawing.Point(124, 91)
        Me.TextCI.Name = "TextCI"
        Me.TextCI.Size = New System.Drawing.Size(100, 20)
        Me.TextCI.TabIndex = 3
        '
        'ComboTipoUsuario
        '
        Me.ComboTipoUsuario.FormattingEnabled = True
        Me.ComboTipoUsuario.Location = New System.Drawing.Point(124, 117)
        Me.ComboTipoUsuario.Name = "ComboTipoUsuario"
        Me.ComboTipoUsuario.Size = New System.Drawing.Size(150, 21)
        Me.ComboTipoUsuario.TabIndex = 4
        '
        'ComboSector
        '
        Me.ComboSector.FormattingEnabled = True
        Me.ComboSector.Location = New System.Drawing.Point(124, 144)
        Me.ComboSector.Name = "ComboSector"
        Me.ComboSector.Size = New System.Drawing.Size(150, 21)
        Me.ComboSector.TabIndex = 5
        '
        'TextUsuario
        '
        Me.TextUsuario.Location = New System.Drawing.Point(124, 171)
        Me.TextUsuario.Name = "TextUsuario"
        Me.TextUsuario.Size = New System.Drawing.Size(100, 20)
        Me.TextUsuario.TabIndex = 6
        '
        'TextPassword
        '
        Me.TextPassword.Enabled = False
        Me.TextPassword.Location = New System.Drawing.Point(124, 197)
        Me.TextPassword.Name = "TextPassword"
        Me.TextPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPassword.Size = New System.Drawing.Size(100, 20)
        Me.TextPassword.TabIndex = 7
        '
        'CheckEliminado
        '
        Me.CheckEliminado.AutoSize = True
        Me.CheckEliminado.Location = New System.Drawing.Point(24, 511)
        Me.CheckEliminado.Name = "CheckEliminado"
        Me.CheckEliminado.Size = New System.Drawing.Size(71, 17)
        Me.CheckEliminado.TabIndex = 8
        Me.CheckEliminado.Text = "Eliminado"
        Me.CheckEliminado.UseVisualStyleBackColor = True
        '
        'TextFoto
        '
        Me.TextFoto.Location = New System.Drawing.Point(124, 223)
        Me.TextFoto.Name = "TextFoto"
        Me.TextFoto.Size = New System.Drawing.Size(150, 20)
        Me.TextFoto.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Sexo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Doc. Identidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Tipo de usuario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Sector"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Usuario"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Contraseña"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 226)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Foto"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Entrada"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(79, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Salida"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(234, 511)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 23
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(315, 511)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 24
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Nombre, Me.Sexo, Me.CI})
        Me.DataGridView1.Location = New System.Drawing.Point(544, 15)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(426, 508)
        Me.DataGridView1.TabIndex = 25
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 250
        '
        'Sexo
        '
        Me.Sexo.HeaderText = "Sexo"
        Me.Sexo.Name = "Sexo"
        Me.Sexo.Width = 50
        '
        'CI
        '
        Me.CI.HeaderText = "Doc. Identidad"
        Me.CI.Name = "CI"
        Me.CI.Width = 120
        '
        'DateCSalud
        '
        Me.DateCSalud.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateCSalud.Location = New System.Drawing.Point(124, 249)
        Me.DateCSalud.Name = "DateCSalud"
        Me.DateCSalud.Size = New System.Drawing.Size(100, 20)
        Me.DateCSalud.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 255)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Carnét de salud"
        '
        'CheckCambiar
        '
        Me.CheckCambiar.AutoSize = True
        Me.CheckCambiar.Location = New System.Drawing.Point(230, 200)
        Me.CheckCambiar.Name = "CheckCambiar"
        Me.CheckCambiar.Size = New System.Drawing.Size(64, 17)
        Me.CheckCambiar.TabIndex = 28
        Me.CheckCambiar.Text = "Cambiar"
        Me.CheckCambiar.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(21, 342)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Lunes"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(21, 368)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Martes"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(21, 394)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Miércoles"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(21, 420)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Jueves"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(21, 446)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "Viernes"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(21, 472)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 13)
        Me.Label18.TabIndex = 44
        Me.Label18.Text = "Sábado"
        '
        'TextEntra
        '
        Me.TextEntra.Location = New System.Drawing.Point(15, 37)
        Me.TextEntra.Mask = "00:00"
        Me.TextEntra.Name = "TextEntra"
        Me.TextEntra.Size = New System.Drawing.Size(48, 20)
        Me.TextEntra.TabIndex = 30
        Me.TextEntra.ValidatingType = GetType(Date)
        '
        'TextSale
        '
        Me.TextSale.Location = New System.Drawing.Point(82, 37)
        Me.TextSale.Mask = "00:00"
        Me.TextSale.Name = "TextSale"
        Me.TextSale.Size = New System.Drawing.Size(48, 20)
        Me.TextSale.TabIndex = 31
        Me.TextSale.ValidatingType = GetType(Date)
        '
        'TextSale2
        '
        Me.TextSale2.Location = New System.Drawing.Point(82, 63)
        Me.TextSale2.Mask = "00:00"
        Me.TextSale2.Name = "TextSale2"
        Me.TextSale2.Size = New System.Drawing.Size(48, 20)
        Me.TextSale2.TabIndex = 33
        Me.TextSale2.ValidatingType = GetType(Date)
        '
        'TextEntra2
        '
        Me.TextEntra2.Location = New System.Drawing.Point(15, 63)
        Me.TextEntra2.Mask = "00:00"
        Me.TextEntra2.Name = "TextEntra2"
        Me.TextEntra2.Size = New System.Drawing.Size(48, 20)
        Me.TextEntra2.TabIndex = 32
        Me.TextEntra2.ValidatingType = GetType(Date)
        '
        'TextSale3
        '
        Me.TextSale3.Location = New System.Drawing.Point(82, 89)
        Me.TextSale3.Mask = "00:00"
        Me.TextSale3.Name = "TextSale3"
        Me.TextSale3.Size = New System.Drawing.Size(48, 20)
        Me.TextSale3.TabIndex = 35
        Me.TextSale3.ValidatingType = GetType(Date)
        '
        'TextEntra3
        '
        Me.TextEntra3.Location = New System.Drawing.Point(15, 89)
        Me.TextEntra3.Mask = "00:00"
        Me.TextEntra3.Name = "TextEntra3"
        Me.TextEntra3.Size = New System.Drawing.Size(48, 20)
        Me.TextEntra3.TabIndex = 34
        Me.TextEntra3.ValidatingType = GetType(Date)
        '
        'TextSale4
        '
        Me.TextSale4.Location = New System.Drawing.Point(82, 115)
        Me.TextSale4.Mask = "00:00"
        Me.TextSale4.Name = "TextSale4"
        Me.TextSale4.Size = New System.Drawing.Size(48, 20)
        Me.TextSale4.TabIndex = 37
        Me.TextSale4.ValidatingType = GetType(Date)
        '
        'TextEntra4
        '
        Me.TextEntra4.Location = New System.Drawing.Point(15, 115)
        Me.TextEntra4.Mask = "00:00"
        Me.TextEntra4.Name = "TextEntra4"
        Me.TextEntra4.Size = New System.Drawing.Size(48, 20)
        Me.TextEntra4.TabIndex = 36
        Me.TextEntra4.ValidatingType = GetType(Date)
        '
        'TextSale5
        '
        Me.TextSale5.Location = New System.Drawing.Point(82, 141)
        Me.TextSale5.Mask = "00:00"
        Me.TextSale5.Name = "TextSale5"
        Me.TextSale5.Size = New System.Drawing.Size(48, 20)
        Me.TextSale5.TabIndex = 39
        Me.TextSale5.ValidatingType = GetType(Date)
        '
        'TextEntra5
        '
        Me.TextEntra5.Location = New System.Drawing.Point(15, 141)
        Me.TextEntra5.Mask = "00:00"
        Me.TextEntra5.Name = "TextEntra5"
        Me.TextEntra5.Size = New System.Drawing.Size(48, 20)
        Me.TextEntra5.TabIndex = 38
        Me.TextEntra5.ValidatingType = GetType(Date)
        '
        'TextSale6
        '
        Me.TextSale6.Location = New System.Drawing.Point(82, 167)
        Me.TextSale6.Mask = "00:00"
        Me.TextSale6.Name = "TextSale6"
        Me.TextSale6.Size = New System.Drawing.Size(48, 20)
        Me.TextSale6.TabIndex = 41
        Me.TextSale6.ValidatingType = GetType(Date)
        '
        'TextEntra6
        '
        Me.TextEntra6.Location = New System.Drawing.Point(15, 167)
        Me.TextEntra6.Mask = "00:00"
        Me.TextEntra6.Name = "TextEntra6"
        Me.TextEntra6.Size = New System.Drawing.Size(48, 20)
        Me.TextEntra6.TabIndex = 40
        Me.TextEntra6.ValidatingType = GetType(Date)
        '
        'RadioCorrido
        '
        Me.RadioCorrido.AutoSize = True
        Me.RadioCorrido.Location = New System.Drawing.Point(24, 286)
        Me.RadioCorrido.Name = "RadioCorrido"
        Me.RadioCorrido.Size = New System.Drawing.Size(94, 17)
        Me.RadioCorrido.TabIndex = 27
        Me.RadioCorrido.TabStop = True
        Me.RadioCorrido.Text = "Horario corrido"
        Me.RadioCorrido.UseVisualStyleBackColor = True
        '
        'RadioCortado
        '
        Me.RadioCortado.AutoSize = True
        Me.RadioCortado.Location = New System.Drawing.Point(124, 286)
        Me.RadioCortado.Name = "RadioCortado"
        Me.RadioCortado.Size = New System.Drawing.Size(98, 17)
        Me.RadioCortado.TabIndex = 28
        Me.RadioCortado.TabStop = True
        Me.RadioCortado.Text = "Horario cortado"
        Me.RadioCortado.UseVisualStyleBackColor = True
        '
        'RadioRotativo
        '
        Me.RadioRotativo.AutoSize = True
        Me.RadioRotativo.Location = New System.Drawing.Point(228, 286)
        Me.RadioRotativo.Name = "RadioRotativo"
        Me.RadioRotativo.Size = New System.Drawing.Size(97, 17)
        Me.RadioRotativo.TabIndex = 28
        Me.RadioRotativo.TabStop = True
        Me.RadioRotativo.Text = "Horario rotativo"
        Me.RadioRotativo.UseVisualStyleBackColor = True
        '
        'GroupCorrido
        '
        Me.GroupCorrido.Controls.Add(Me.TextSale)
        Me.GroupCorrido.Controls.Add(Me.Label10)
        Me.GroupCorrido.Controls.Add(Me.Label11)
        Me.GroupCorrido.Controls.Add(Me.TextEntra)
        Me.GroupCorrido.Controls.Add(Me.TextEntra2)
        Me.GroupCorrido.Controls.Add(Me.TextSale2)
        Me.GroupCorrido.Controls.Add(Me.TextEntra3)
        Me.GroupCorrido.Controls.Add(Me.TextSale3)
        Me.GroupCorrido.Controls.Add(Me.TextEntra4)
        Me.GroupCorrido.Controls.Add(Me.TextSale4)
        Me.GroupCorrido.Controls.Add(Me.TextEntra5)
        Me.GroupCorrido.Controls.Add(Me.TextSale5)
        Me.GroupCorrido.Controls.Add(Me.TextEntra6)
        Me.GroupCorrido.Controls.Add(Me.TextSale6)
        Me.GroupCorrido.Location = New System.Drawing.Point(79, 306)
        Me.GroupCorrido.Name = "GroupCorrido"
        Me.GroupCorrido.Size = New System.Drawing.Size(149, 199)
        Me.GroupCorrido.TabIndex = 95
        Me.GroupCorrido.TabStop = False
        '
        'GroupCortado
        '
        Me.GroupCortado.Controls.Add(Me.TextSaleC)
        Me.GroupCortado.Controls.Add(Me.Label21)
        Me.GroupCortado.Controls.Add(Me.Label22)
        Me.GroupCortado.Controls.Add(Me.TextEntraC)
        Me.GroupCortado.Controls.Add(Me.TextEntraC2)
        Me.GroupCortado.Controls.Add(Me.TextSaleC2)
        Me.GroupCortado.Controls.Add(Me.TextEntraC3)
        Me.GroupCortado.Controls.Add(Me.TextSaleC3)
        Me.GroupCortado.Controls.Add(Me.TextEntraC4)
        Me.GroupCortado.Controls.Add(Me.TextSaleC4)
        Me.GroupCortado.Controls.Add(Me.TextEntraC5)
        Me.GroupCortado.Controls.Add(Me.TextSaleC5)
        Me.GroupCortado.Controls.Add(Me.TextEntraC6)
        Me.GroupCortado.Controls.Add(Me.TextSaleC6)
        Me.GroupCortado.Location = New System.Drawing.Point(234, 306)
        Me.GroupCortado.Name = "GroupCortado"
        Me.GroupCortado.Size = New System.Drawing.Size(149, 199)
        Me.GroupCortado.TabIndex = 96
        Me.GroupCortado.TabStop = False
        '
        'TextSaleC
        '
        Me.TextSaleC.Location = New System.Drawing.Point(82, 37)
        Me.TextSaleC.Mask = "00:00"
        Me.TextSaleC.Name = "TextSaleC"
        Me.TextSaleC.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleC.TabIndex = 43
        Me.TextSaleC.ValidatingType = GetType(Date)
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(44, 13)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Entrada"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(79, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(36, 13)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Salida"
        '
        'TextEntraC
        '
        Me.TextEntraC.Location = New System.Drawing.Point(15, 37)
        Me.TextEntraC.Mask = "00:00"
        Me.TextEntraC.Name = "TextEntraC"
        Me.TextEntraC.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraC.TabIndex = 42
        Me.TextEntraC.ValidatingType = GetType(Date)
        '
        'TextEntraC2
        '
        Me.TextEntraC2.Location = New System.Drawing.Point(15, 63)
        Me.TextEntraC2.Mask = "00:00"
        Me.TextEntraC2.Name = "TextEntraC2"
        Me.TextEntraC2.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraC2.TabIndex = 44
        Me.TextEntraC2.ValidatingType = GetType(Date)
        '
        'TextSaleC2
        '
        Me.TextSaleC2.Location = New System.Drawing.Point(82, 63)
        Me.TextSaleC2.Mask = "00:00"
        Me.TextSaleC2.Name = "TextSaleC2"
        Me.TextSaleC2.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleC2.TabIndex = 45
        Me.TextSaleC2.ValidatingType = GetType(Date)
        '
        'TextEntraC3
        '
        Me.TextEntraC3.Location = New System.Drawing.Point(15, 89)
        Me.TextEntraC3.Mask = "00:00"
        Me.TextEntraC3.Name = "TextEntraC3"
        Me.TextEntraC3.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraC3.TabIndex = 46
        Me.TextEntraC3.ValidatingType = GetType(Date)
        '
        'TextSaleC3
        '
        Me.TextSaleC3.Location = New System.Drawing.Point(82, 89)
        Me.TextSaleC3.Mask = "00:00"
        Me.TextSaleC3.Name = "TextSaleC3"
        Me.TextSaleC3.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleC3.TabIndex = 47
        Me.TextSaleC3.ValidatingType = GetType(Date)
        '
        'TextEntraC4
        '
        Me.TextEntraC4.Location = New System.Drawing.Point(15, 115)
        Me.TextEntraC4.Mask = "00:00"
        Me.TextEntraC4.Name = "TextEntraC4"
        Me.TextEntraC4.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraC4.TabIndex = 48
        Me.TextEntraC4.ValidatingType = GetType(Date)
        '
        'TextSaleC4
        '
        Me.TextSaleC4.Location = New System.Drawing.Point(82, 115)
        Me.TextSaleC4.Mask = "00:00"
        Me.TextSaleC4.Name = "TextSaleC4"
        Me.TextSaleC4.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleC4.TabIndex = 49
        Me.TextSaleC4.ValidatingType = GetType(Date)
        '
        'TextEntraC5
        '
        Me.TextEntraC5.Location = New System.Drawing.Point(15, 141)
        Me.TextEntraC5.Mask = "00:00"
        Me.TextEntraC5.Name = "TextEntraC5"
        Me.TextEntraC5.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraC5.TabIndex = 50
        Me.TextEntraC5.ValidatingType = GetType(Date)
        '
        'TextSaleC5
        '
        Me.TextSaleC5.Location = New System.Drawing.Point(82, 141)
        Me.TextSaleC5.Mask = "00:00"
        Me.TextSaleC5.Name = "TextSaleC5"
        Me.TextSaleC5.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleC5.TabIndex = 51
        Me.TextSaleC5.ValidatingType = GetType(Date)
        '
        'TextEntraC6
        '
        Me.TextEntraC6.Location = New System.Drawing.Point(15, 167)
        Me.TextEntraC6.Mask = "00:00"
        Me.TextEntraC6.Name = "TextEntraC6"
        Me.TextEntraC6.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraC6.TabIndex = 52
        Me.TextEntraC6.ValidatingType = GetType(Date)
        '
        'TextSaleC6
        '
        Me.TextSaleC6.Location = New System.Drawing.Point(82, 167)
        Me.TextSaleC6.Mask = "00:00"
        Me.TextSaleC6.Name = "TextSaleC6"
        Me.TextSaleC6.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleC6.TabIndex = 53
        Me.TextSaleC6.ValidatingType = GetType(Date)
        '
        'GroupRotativo
        '
        Me.GroupRotativo.Controls.Add(Me.TextSaleR)
        Me.GroupRotativo.Controls.Add(Me.Label19)
        Me.GroupRotativo.Controls.Add(Me.Label20)
        Me.GroupRotativo.Controls.Add(Me.TextEntraR)
        Me.GroupRotativo.Controls.Add(Me.TextEntraR2)
        Me.GroupRotativo.Controls.Add(Me.TextSaleR2)
        Me.GroupRotativo.Controls.Add(Me.TextEntraR3)
        Me.GroupRotativo.Controls.Add(Me.TextSaleR3)
        Me.GroupRotativo.Controls.Add(Me.TextEntraR4)
        Me.GroupRotativo.Controls.Add(Me.TextSaleR4)
        Me.GroupRotativo.Controls.Add(Me.TextEntraR5)
        Me.GroupRotativo.Controls.Add(Me.TextSaleR5)
        Me.GroupRotativo.Controls.Add(Me.TextEntraR6)
        Me.GroupRotativo.Controls.Add(Me.TextSaleR6)
        Me.GroupRotativo.Location = New System.Drawing.Point(389, 306)
        Me.GroupRotativo.Name = "GroupRotativo"
        Me.GroupRotativo.Size = New System.Drawing.Size(149, 199)
        Me.GroupRotativo.TabIndex = 96
        Me.GroupRotativo.TabStop = False
        '
        'TextSaleR
        '
        Me.TextSaleR.Location = New System.Drawing.Point(82, 37)
        Me.TextSaleR.Mask = "00:00"
        Me.TextSaleR.Name = "TextSaleR"
        Me.TextSaleR.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleR.TabIndex = 55
        Me.TextSaleR.ValidatingType = GetType(Date)
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 13)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Entrada"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(79, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 13)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Salida"
        '
        'TextEntraR
        '
        Me.TextEntraR.Location = New System.Drawing.Point(15, 37)
        Me.TextEntraR.Mask = "00:00"
        Me.TextEntraR.Name = "TextEntraR"
        Me.TextEntraR.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraR.TabIndex = 54
        Me.TextEntraR.ValidatingType = GetType(Date)
        '
        'TextEntraR2
        '
        Me.TextEntraR2.Location = New System.Drawing.Point(15, 63)
        Me.TextEntraR2.Mask = "00:00"
        Me.TextEntraR2.Name = "TextEntraR2"
        Me.TextEntraR2.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraR2.TabIndex = 56
        Me.TextEntraR2.ValidatingType = GetType(Date)
        '
        'TextSaleR2
        '
        Me.TextSaleR2.Location = New System.Drawing.Point(82, 63)
        Me.TextSaleR2.Mask = "00:00"
        Me.TextSaleR2.Name = "TextSaleR2"
        Me.TextSaleR2.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleR2.TabIndex = 57
        Me.TextSaleR2.ValidatingType = GetType(Date)
        '
        'TextEntraR3
        '
        Me.TextEntraR3.Location = New System.Drawing.Point(15, 89)
        Me.TextEntraR3.Mask = "00:00"
        Me.TextEntraR3.Name = "TextEntraR3"
        Me.TextEntraR3.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraR3.TabIndex = 58
        Me.TextEntraR3.ValidatingType = GetType(Date)
        '
        'TextSaleR3
        '
        Me.TextSaleR3.Location = New System.Drawing.Point(82, 89)
        Me.TextSaleR3.Mask = "00:00"
        Me.TextSaleR3.Name = "TextSaleR3"
        Me.TextSaleR3.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleR3.TabIndex = 59
        Me.TextSaleR3.ValidatingType = GetType(Date)
        '
        'TextEntraR4
        '
        Me.TextEntraR4.Location = New System.Drawing.Point(15, 115)
        Me.TextEntraR4.Mask = "00:00"
        Me.TextEntraR4.Name = "TextEntraR4"
        Me.TextEntraR4.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraR4.TabIndex = 60
        Me.TextEntraR4.ValidatingType = GetType(Date)
        '
        'TextSaleR4
        '
        Me.TextSaleR4.Location = New System.Drawing.Point(82, 115)
        Me.TextSaleR4.Mask = "00:00"
        Me.TextSaleR4.Name = "TextSaleR4"
        Me.TextSaleR4.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleR4.TabIndex = 61
        Me.TextSaleR4.ValidatingType = GetType(Date)
        '
        'TextEntraR5
        '
        Me.TextEntraR5.Location = New System.Drawing.Point(15, 141)
        Me.TextEntraR5.Mask = "00:00"
        Me.TextEntraR5.Name = "TextEntraR5"
        Me.TextEntraR5.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraR5.TabIndex = 62
        Me.TextEntraR5.ValidatingType = GetType(Date)
        '
        'TextSaleR5
        '
        Me.TextSaleR5.Location = New System.Drawing.Point(82, 141)
        Me.TextSaleR5.Mask = "00:00"
        Me.TextSaleR5.Name = "TextSaleR5"
        Me.TextSaleR5.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleR5.TabIndex = 63
        Me.TextSaleR5.ValidatingType = GetType(Date)
        '
        'TextEntraR6
        '
        Me.TextEntraR6.Location = New System.Drawing.Point(15, 167)
        Me.TextEntraR6.Mask = "00:00"
        Me.TextEntraR6.Name = "TextEntraR6"
        Me.TextEntraR6.Size = New System.Drawing.Size(48, 20)
        Me.TextEntraR6.TabIndex = 64
        Me.TextEntraR6.ValidatingType = GetType(Date)
        '
        'TextSaleR6
        '
        Me.TextSaleR6.Location = New System.Drawing.Point(82, 167)
        Me.TextSaleR6.Mask = "00:00"
        Me.TextSaleR6.Name = "TextSaleR6"
        Me.TextSaleR6.Size = New System.Drawing.Size(48, 20)
        Me.TextSaleR6.TabIndex = 65
        Me.TextSaleR6.ValidatingType = GetType(Date)
        '
        'FormUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 542)
        Me.Controls.Add(Me.GroupRotativo)
        Me.Controls.Add(Me.GroupCortado)
        Me.Controls.Add(Me.GroupCorrido)
        Me.Controls.Add(Me.RadioRotativo)
        Me.Controls.Add(Me.RadioCortado)
        Me.Controls.Add(Me.RadioCorrido)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.CheckCambiar)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DateCSalud)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNuevo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFoto)
        Me.Controls.Add(Me.CheckEliminado)
        Me.Controls.Add(Me.TextPassword)
        Me.Controls.Add(Me.TextUsuario)
        Me.Controls.Add(Me.ComboSector)
        Me.Controls.Add(Me.ComboTipoUsuario)
        Me.Controls.Add(Me.TextCI)
        Me.Controls.Add(Me.ComboSexo)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.TextId)
        Me.Name = "FormUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupCorrido.ResumeLayout(False)
        Me.GroupCorrido.PerformLayout()
        Me.GroupCortado.ResumeLayout(False)
        Me.GroupCortado.PerformLayout()
        Me.GroupRotativo.ResumeLayout(False)
        Me.GroupRotativo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents ComboSexo As System.Windows.Forms.ComboBox
    Friend WithEvents TextCI As System.Windows.Forms.TextBox
    Friend WithEvents ComboTipoUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents ComboSector As System.Windows.Forms.ComboBox
    Friend WithEvents TextUsuario As System.Windows.Forms.TextBox
    Friend WithEvents TextPassword As System.Windows.Forms.TextBox
    Friend WithEvents CheckEliminado As System.Windows.Forms.CheckBox
    Friend WithEvents TextFoto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sexo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCSalud As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckCambiar As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextEntra As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSale As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSale2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntra2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSale3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntra3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSale4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntra4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSale5 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntra5 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSale6 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntra6 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents RadioCorrido As System.Windows.Forms.RadioButton
    Friend WithEvents RadioCortado As System.Windows.Forms.RadioButton
    Friend WithEvents RadioRotativo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupCorrido As System.Windows.Forms.GroupBox
    Friend WithEvents GroupCortado As System.Windows.Forms.GroupBox
    Friend WithEvents TextSaleC As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextEntraC As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntraC2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSaleC2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntraC3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSaleC3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntraC4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSaleC4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntraC5 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSaleC5 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntraC6 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSaleC6 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupRotativo As System.Windows.Forms.GroupBox
    Friend WithEvents TextSaleR As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextEntraR As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntraR2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSaleR2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntraR3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSaleR3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntraR4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSaleR4 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntraR5 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSaleR5 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextEntraR6 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TextSaleR6 As System.Windows.Forms.MaskedTextBox
End Class
