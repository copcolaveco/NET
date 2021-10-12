<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaDePrecios
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
        Me.TextCodigo = New System.Windows.Forms.TextBox()
        Me.TextDescripcion = New System.Windows.Forms.TextBox()
        Me.TextPrecio1 = New System.Windows.Forms.TextBox()
        Me.TextPrecio2 = New System.Windows.Forms.TextBox()
        Me.TextPrecio3 = New System.Windows.Forms.TextBox()
        Me.TextPrecio4 = New System.Windows.Forms.TextBox()
        Me.TextPrecio5 = New System.Windows.Forms.TextBox()
        Me.TextPrecio6 = New System.Windows.Forms.TextBox()
        Me.TextPrecio7 = New System.Windows.Forms.TextBox()
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
        Me.ButtonNuevo = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analisis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComboTI = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ButtonDuplicar = New System.Windows.Forms.Button()
        Me.CheckPaquete = New System.Windows.Forms.CheckBox()
        Me.CheckOcultar = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextFiltro = New System.Windows.Forms.TextBox()
        Me.ButtonTodos = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ComboFiltro = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ButtonMeta = New System.Windows.Forms.Button()
        Me.LabelResultado = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ComboResultados = New System.Windows.Forms.ComboBox()
        Me.TextOrden = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ButtonEnsayo = New System.Windows.Forms.Button()
        Me.CheckAcreditado = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextAbreviatura = New System.Windows.Forms.TextBox()
        Me.ButtonUnidades = New System.Windows.Forms.Button()
        Me.ButtonTodos2 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboFiltro2 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ButtonMetodos = New System.Windows.Forms.Button()
        Me.TextIdCR = New System.Windows.Forms.TextBox()
        Me.ListOpciones = New System.Windows.Forms.ListBox()
        Me.ButtonQuitar = New System.Windows.Forms.Button()
        Me.ButtonAgregar = New System.Windows.Forms.Button()
        Me.TextOpciones = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescTecnica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abreviatura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Analisis2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoControl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboTipoControl = New System.Windows.Forms.ComboBox()
        Me.TextDescTecnica = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(90, 12)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(52, 20)
        Me.TextId.TabIndex = 0
        '
        'TextCodigo
        '
        Me.TextCodigo.Location = New System.Drawing.Point(90, 38)
        Me.TextCodigo.Name = "TextCodigo"
        Me.TextCodigo.Size = New System.Drawing.Size(100, 20)
        Me.TextCodigo.TabIndex = 1
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(90, 64)
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(256, 20)
        Me.TextDescripcion.TabIndex = 2
        '
        'TextPrecio1
        '
        Me.TextPrecio1.Location = New System.Drawing.Point(90, 90)
        Me.TextPrecio1.Name = "TextPrecio1"
        Me.TextPrecio1.Size = New System.Drawing.Size(64, 20)
        Me.TextPrecio1.TabIndex = 3
        '
        'TextPrecio2
        '
        Me.TextPrecio2.Location = New System.Drawing.Point(89, 116)
        Me.TextPrecio2.Name = "TextPrecio2"
        Me.TextPrecio2.Size = New System.Drawing.Size(65, 20)
        Me.TextPrecio2.TabIndex = 4
        '
        'TextPrecio3
        '
        Me.TextPrecio3.Location = New System.Drawing.Point(89, 142)
        Me.TextPrecio3.Name = "TextPrecio3"
        Me.TextPrecio3.Size = New System.Drawing.Size(65, 20)
        Me.TextPrecio3.TabIndex = 5
        '
        'TextPrecio4
        '
        Me.TextPrecio4.Location = New System.Drawing.Point(90, 168)
        Me.TextPrecio4.Name = "TextPrecio4"
        Me.TextPrecio4.Size = New System.Drawing.Size(64, 20)
        Me.TextPrecio4.TabIndex = 6
        '
        'TextPrecio5
        '
        Me.TextPrecio5.Location = New System.Drawing.Point(90, 194)
        Me.TextPrecio5.Name = "TextPrecio5"
        Me.TextPrecio5.Size = New System.Drawing.Size(64, 20)
        Me.TextPrecio5.TabIndex = 7
        '
        'TextPrecio6
        '
        Me.TextPrecio6.Location = New System.Drawing.Point(90, 220)
        Me.TextPrecio6.Name = "TextPrecio6"
        Me.TextPrecio6.Size = New System.Drawing.Size(64, 20)
        Me.TextPrecio6.TabIndex = 8
        '
        'TextPrecio7
        '
        Me.TextPrecio7.Location = New System.Drawing.Point(90, 246)
        Me.TextPrecio7.Name = "TextPrecio7"
        Me.TextPrecio7.Size = New System.Drawing.Size(64, 20)
        Me.TextPrecio7.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Código"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Descripción"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Precio 1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Precio 2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Precio 3"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Precio 4"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Precio 5"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 223)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Precio 6"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 249)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Precio 7"
        '
        'ButtonNuevo
        '
        Me.ButtonNuevo.Location = New System.Drawing.Point(41, 314)
        Me.ButtonNuevo.Name = "ButtonNuevo"
        Me.ButtonNuevo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNuevo.TabIndex = 20
        Me.ButtonNuevo.Text = "Nuevo"
        Me.ButtonNuevo.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(122, 314)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 21
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(203, 314)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEliminar.TabIndex = 22
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Codigo, Me.Descripcion, Me.Analisis, Me.Precio1, Me.Precio2, Me.Precio3, Me.Precio4, Me.Precio5, Me.Precio6, Me.Precio7})
        Me.DataGridView1.Location = New System.Drawing.Point(367, 38)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(716, 539)
        Me.DataGridView1.TabIndex = 23
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 80
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 350
        '
        'Analisis
        '
        Me.Analisis.HeaderText = "Analisis"
        Me.Analisis.Name = "Analisis"
        '
        'Precio1
        '
        Me.Precio1.HeaderText = "Precio 1"
        Me.Precio1.Name = "Precio1"
        Me.Precio1.Width = 60
        '
        'Precio2
        '
        Me.Precio2.HeaderText = "Precio 2"
        Me.Precio2.Name = "Precio2"
        Me.Precio2.Width = 60
        '
        'Precio3
        '
        Me.Precio3.HeaderText = "Precio 3"
        Me.Precio3.Name = "Precio3"
        Me.Precio3.Width = 60
        '
        'Precio4
        '
        Me.Precio4.HeaderText = "Precio 4"
        Me.Precio4.Name = "Precio4"
        Me.Precio4.Width = 60
        '
        'Precio5
        '
        Me.Precio5.HeaderText = "Precio 5"
        Me.Precio5.Name = "Precio5"
        Me.Precio5.Width = 60
        '
        'Precio6
        '
        Me.Precio6.HeaderText = "Precio 6"
        Me.Precio6.Name = "Precio6"
        Me.Precio6.Width = 60
        '
        'Precio7
        '
        Me.Precio7.HeaderText = "Precio 7"
        Me.Precio7.Name = "Precio7"
        Me.Precio7.Width = 60
        '
        'ComboTI
        '
        Me.ComboTI.FormattingEnabled = True
        Me.ComboTI.Location = New System.Drawing.Point(89, 272)
        Me.ComboTI.Name = "ComboTI"
        Me.ComboTI.Size = New System.Drawing.Size(189, 21)
        Me.ComboTI.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 275)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Tipo informe"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1111, 618)
        Me.TabControl1.TabIndex = 26
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ButtonDuplicar)
        Me.TabPage1.Controls.Add(Me.CheckPaquete)
        Me.TabPage1.Controls.Add(Me.CheckOcultar)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.TextFiltro)
        Me.TabPage1.Controls.Add(Me.ButtonTodos)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.ComboFiltro)
        Me.TabPage1.Controls.Add(Me.TextPrecio3)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.TextId)
        Me.TabPage1.Controls.Add(Me.ComboTI)
        Me.TabPage1.Controls.Add(Me.TextCodigo)
        Me.TabPage1.Controls.Add(Me.TextDescripcion)
        Me.TabPage1.Controls.Add(Me.ButtonEliminar)
        Me.TabPage1.Controls.Add(Me.TextPrecio1)
        Me.TabPage1.Controls.Add(Me.ButtonGuardar)
        Me.TabPage1.Controls.Add(Me.TextPrecio2)
        Me.TabPage1.Controls.Add(Me.ButtonNuevo)
        Me.TabPage1.Controls.Add(Me.TextPrecio4)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.TextPrecio5)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.TextPrecio6)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.TextPrecio7)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1103, 592)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Facturación"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ButtonDuplicar
        '
        Me.ButtonDuplicar.Location = New System.Drawing.Point(13, 518)
        Me.ButtonDuplicar.Name = "ButtonDuplicar"
        Me.ButtonDuplicar.Size = New System.Drawing.Size(129, 23)
        Me.ButtonDuplicar.TabIndex = 32
        Me.ButtonDuplicar.Text = "Duplicar Analisis"
        Me.ButtonDuplicar.UseVisualStyleBackColor = True
        '
        'CheckPaquete
        '
        Me.CheckPaquete.AutoSize = True
        Me.CheckPaquete.Location = New System.Drawing.Point(203, 40)
        Me.CheckPaquete.Name = "CheckPaquete"
        Me.CheckPaquete.Size = New System.Drawing.Size(66, 17)
        Me.CheckPaquete.TabIndex = 31
        Me.CheckPaquete.Text = "Paquete"
        Me.CheckPaquete.UseVisualStyleBackColor = True
        '
        'CheckOcultar
        '
        Me.CheckOcultar.AutoSize = True
        Me.CheckOcultar.Location = New System.Drawing.Point(18, 560)
        Me.CheckOcultar.Name = "CheckOcultar"
        Me.CheckOcultar.Size = New System.Drawing.Size(209, 17)
        Me.CheckOcultar.TabIndex = 30
        Me.CheckOcultar.Text = "Ocultar en listado de analisis (Solicitud)"
        Me.CheckOcultar.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(364, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(107, 13)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "Filtrar por descripción"
        '
        'TextFiltro
        '
        Me.TextFiltro.Location = New System.Drawing.Point(477, 11)
        Me.TextFiltro.Name = "TextFiltro"
        Me.TextFiltro.Size = New System.Drawing.Size(250, 20)
        Me.TextFiltro.TabIndex = 27
        '
        'ButtonTodos
        '
        Me.ButtonTodos.Location = New System.Drawing.Point(1008, 9)
        Me.ButtonTodos.Name = "ButtonTodos"
        Me.ButtonTodos.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTodos.TabIndex = 28
        Me.ButtonTodos.Text = "Todos"
        Me.ButtonTodos.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(754, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Filtrar por:"
        '
        'ComboFiltro
        '
        Me.ComboFiltro.FormattingEnabled = True
        Me.ComboFiltro.Location = New System.Drawing.Point(813, 11)
        Me.ComboFiltro.Name = "ComboFiltro"
        Me.ComboFiltro.Size = New System.Drawing.Size(189, 21)
        Me.ComboFiltro.TabIndex = 26
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.ButtonMeta)
        Me.TabPage2.Controls.Add(Me.LabelResultado)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.ComboResultados)
        Me.TabPage2.Controls.Add(Me.TextOrden)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.ButtonEnsayo)
        Me.TabPage2.Controls.Add(Me.CheckAcreditado)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.TextAbreviatura)
        Me.TabPage2.Controls.Add(Me.ButtonUnidades)
        Me.TabPage2.Controls.Add(Me.ButtonTodos2)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.ComboFiltro2)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.ButtonMetodos)
        Me.TabPage2.Controls.Add(Me.TextIdCR)
        Me.TabPage2.Controls.Add(Me.ListOpciones)
        Me.TabPage2.Controls.Add(Me.ButtonQuitar)
        Me.TabPage2.Controls.Add(Me.ButtonAgregar)
        Me.TabPage2.Controls.Add(Me.TextOpciones)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.ComboTipoControl)
        Me.TabPage2.Controls.Add(Me.TextDescTecnica)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1103, 592)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Configuración técnica"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ButtonMeta
        '
        Me.ButtonMeta.Location = New System.Drawing.Point(18, 341)
        Me.ButtonMeta.Name = "ButtonMeta"
        Me.ButtonMeta.Size = New System.Drawing.Size(110, 23)
        Me.ButtonMeta.TabIndex = 75
        Me.ButtonMeta.Text = "Meta"
        Me.ButtonMeta.UseVisualStyleBackColor = True
        '
        'LabelResultado
        '
        Me.LabelResultado.AutoSize = True
        Me.LabelResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelResultado.Location = New System.Drawing.Point(15, 481)
        Me.LabelResultado.Name = "LabelResultado"
        Me.LabelResultado.Size = New System.Drawing.Size(0, 12)
        Me.LabelResultado.TabIndex = 74
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(15, 432)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 13)
        Me.Label22.TabIndex = 73
        Me.Label22.Text = "Mostrar resultados"
        '
        'ComboResultados
        '
        Me.ComboResultados.FormattingEnabled = True
        Me.ComboResultados.Items.AddRange(New Object() {"Ninguno", "Resultado 1", "Resultado 2", "Resultado 1 y 2"})
        Me.ComboResultados.Location = New System.Drawing.Point(18, 448)
        Me.ComboResultados.Name = "ComboResultados"
        Me.ComboResultados.Size = New System.Drawing.Size(202, 21)
        Me.ComboResultados.TabIndex = 72
        '
        'TextOrden
        '
        Me.TextOrden.Location = New System.Drawing.Point(99, 513)
        Me.TextOrden.Name = "TextOrden"
        Me.TextOrden.Size = New System.Drawing.Size(60, 20)
        Me.TextOrden.TabIndex = 71
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(15, 516)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 70
        Me.Label18.Text = "Orden en listado"
        '
        'ButtonEnsayo
        '
        Me.ButtonEnsayo.Location = New System.Drawing.Point(145, 383)
        Me.ButtonEnsayo.Name = "ButtonEnsayo"
        Me.ButtonEnsayo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEnsayo.TabIndex = 69
        Me.ButtonEnsayo.Text = "Ensayo"
        Me.ButtonEnsayo.UseVisualStyleBackColor = True
        '
        'CheckAcreditado
        '
        Me.CheckAcreditado.AutoSize = True
        Me.CheckAcreditado.Location = New System.Drawing.Point(18, 387)
        Me.CheckAcreditado.Name = "CheckAcreditado"
        Me.CheckAcreditado.Size = New System.Drawing.Size(121, 17)
        Me.CheckAcreditado.TabIndex = 68
        Me.CheckAcreditado.Text = "Acreditado por OUA"
        Me.CheckAcreditado.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(15, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 13)
        Me.Label19.TabIndex = 66
        Me.Label19.Text = "Abreviatura"
        '
        'TextAbreviatura
        '
        Me.TextAbreviatura.Location = New System.Drawing.Point(90, 48)
        Me.TextAbreviatura.Name = "TextAbreviatura"
        Me.TextAbreviatura.Size = New System.Drawing.Size(134, 20)
        Me.TextAbreviatura.TabIndex = 65
        '
        'ButtonUnidades
        '
        Me.ButtonUnidades.Location = New System.Drawing.Point(18, 312)
        Me.ButtonUnidades.Name = "ButtonUnidades"
        Me.ButtonUnidades.Size = New System.Drawing.Size(110, 23)
        Me.ButtonUnidades.TabIndex = 64
        Me.ButtonUnidades.Text = "Cargar unidades"
        Me.ButtonUnidades.UseVisualStyleBackColor = True
        '
        'ButtonTodos2
        '
        Me.ButtonTodos2.Location = New System.Drawing.Point(613, 9)
        Me.ButtonTodos2.Name = "ButtonTodos2"
        Me.ButtonTodos2.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTodos2.TabIndex = 63
        Me.ButtonTodos2.Text = "Todos"
        Me.ButtonTodos2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(359, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 62
        Me.Label17.Text = "Filtrar por:"
        '
        'ComboFiltro2
        '
        Me.ComboFiltro2.FormattingEnabled = True
        Me.ComboFiltro2.Location = New System.Drawing.Point(418, 11)
        Me.ComboFiltro2.Name = "ComboFiltro2"
        Me.ComboFiltro2.Size = New System.Drawing.Size(189, 21)
        Me.ComboFiltro2.TabIndex = 61
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 117)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 13)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "del combobox"
        '
        'ButtonMetodos
        '
        Me.ButtonMetodos.Location = New System.Drawing.Point(18, 283)
        Me.ButtonMetodos.Name = "ButtonMetodos"
        Me.ButtonMetodos.Size = New System.Drawing.Size(110, 23)
        Me.ButtonMetodos.TabIndex = 59
        Me.ButtonMetodos.Text = "Cargar métodos"
        Me.ButtonMetodos.UseVisualStyleBackColor = True
        '
        'TextIdCR
        '
        Me.TextIdCR.Location = New System.Drawing.Point(232, 130)
        Me.TextIdCR.Name = "TextIdCR"
        Me.TextIdCR.ReadOnly = True
        Me.TextIdCR.Size = New System.Drawing.Size(44, 20)
        Me.TextIdCR.TabIndex = 58
        Me.TextIdCR.Visible = False
        '
        'ListOpciones
        '
        Me.ListOpciones.FormattingEnabled = True
        Me.ListOpciones.Location = New System.Drawing.Point(90, 130)
        Me.ListOpciones.Name = "ListOpciones"
        Me.ListOpciones.Size = New System.Drawing.Size(136, 147)
        Me.ListOpciones.TabIndex = 57
        '
        'ButtonQuitar
        '
        Me.ButtonQuitar.Location = New System.Drawing.Point(265, 103)
        Me.ButtonQuitar.Name = "ButtonQuitar"
        Me.ButtonQuitar.Size = New System.Drawing.Size(27, 21)
        Me.ButtonQuitar.TabIndex = 56
        Me.ButtonQuitar.Text = "-"
        Me.ButtonQuitar.UseVisualStyleBackColor = True
        '
        'ButtonAgregar
        '
        Me.ButtonAgregar.Location = New System.Drawing.Point(232, 103)
        Me.ButtonAgregar.Name = "ButtonAgregar"
        Me.ButtonAgregar.Size = New System.Drawing.Size(27, 21)
        Me.ButtonAgregar.TabIndex = 55
        Me.ButtonAgregar.Text = "+"
        Me.ButtonAgregar.UseVisualStyleBackColor = True
        '
        'TextOpciones
        '
        Me.TextOpciones.Location = New System.Drawing.Point(90, 104)
        Me.TextOpciones.Name = "TextOpciones"
        Me.TextOpciones.Size = New System.Drawing.Size(136, 20)
        Me.TextOpciones.TabIndex = 54
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "Opciones"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "técnica"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Codigo2, Me.DescTecnica, Me.Abreviatura, Me.Orden, Me.Analisis2, Me.TipoControl})
        Me.DataGridView2.Location = New System.Drawing.Point(360, 37)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(737, 541)
        Me.DataGridView2.TabIndex = 49
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Visible = False
        '
        'Codigo2
        '
        Me.Codigo2.HeaderText = "Código"
        Me.Codigo2.Name = "Codigo2"
        Me.Codigo2.Width = 80
        '
        'DescTecnica
        '
        Me.DescTecnica.HeaderText = "Desc. Técnica"
        Me.DescTecnica.Name = "DescTecnica"
        Me.DescTecnica.Width = 250
        '
        'Abreviatura
        '
        Me.Abreviatura.HeaderText = "Abreviatura"
        Me.Abreviatura.Name = "Abreviatura"
        Me.Abreviatura.Width = 250
        '
        'Orden
        '
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.Width = 50
        '
        'Analisis2
        '
        Me.Analisis2.HeaderText = "Analisis"
        Me.Analisis2.Name = "Analisis2"
        '
        'TipoControl
        '
        Me.TipoControl.HeaderText = "Tipo Control"
        Me.TipoControl.Name = "TipoControl"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Tipo control"
        '
        'ComboTipoControl
        '
        Me.ComboTipoControl.FormattingEnabled = True
        Me.ComboTipoControl.Location = New System.Drawing.Point(90, 74)
        Me.ComboTipoControl.Name = "ComboTipoControl"
        Me.ComboTipoControl.Size = New System.Drawing.Size(189, 21)
        Me.ComboTipoControl.TabIndex = 50
        '
        'TextDescTecnica
        '
        Me.TextDescTecnica.Location = New System.Drawing.Point(90, 12)
        Me.TextDescTecnica.Name = "TextDescTecnica"
        Me.TextDescTecnica.Size = New System.Drawing.Size(256, 20)
        Me.TextDescTecnica.TabIndex = 28
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(180, 555)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "Eliminar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(99, 555)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 47
        Me.Button2.Text = "Guardar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(18, 555)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 46
        Me.Button3.Text = "Nuevo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(15, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 38
        Me.Label21.Text = "Descripción"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(145, 341)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(110, 23)
        Me.Button4.TabIndex = 76
        Me.Button4.Text = "Referencias"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'FormListaDePrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 642)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormListaDePrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de precios"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TextPrecio1 As System.Windows.Forms.TextBox
    Friend WithEvents TextPrecio2 As System.Windows.Forms.TextBox
    Friend WithEvents TextPrecio3 As System.Windows.Forms.TextBox
    Friend WithEvents TextPrecio4 As System.Windows.Forms.TextBox
    Friend WithEvents TextPrecio5 As System.Windows.Forms.TextBox
    Friend WithEvents TextPrecio6 As System.Windows.Forms.TextBox
    Friend WithEvents TextPrecio7 As System.Windows.Forms.TextBox
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
    Friend WithEvents ButtonNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboTI As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analisis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboTipoControl As System.Windows.Forms.ComboBox
    Friend WithEvents TextDescTecnica As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ListOpciones As System.Windows.Forms.ListBox
    Friend WithEvents ButtonQuitar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgregar As System.Windows.Forms.Button
    Friend WithEvents TextOpciones As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextIdCR As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ButtonMetodos As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ComboFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ComboFiltro2 As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonTodos As System.Windows.Forms.Button
    Friend WithEvents ButtonTodos2 As System.Windows.Forms.Button
    Friend WithEvents ButtonUnidades As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextAbreviatura As System.Windows.Forms.TextBox
    Friend WithEvents CheckAcreditado As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonEnsayo As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextFiltro As System.Windows.Forms.TextBox
    Friend WithEvents TextOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescTecnica As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abreviatura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Analisis2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoControl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckOcultar As System.Windows.Forms.CheckBox
    Friend WithEvents CheckPaquete As System.Windows.Forms.CheckBox
    Friend WithEvents ComboResultados As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents LabelResultado As System.Windows.Forms.Label
    Friend WithEvents ButtonDuplicar As System.Windows.Forms.Button
    Friend WithEvents ButtonMeta As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
