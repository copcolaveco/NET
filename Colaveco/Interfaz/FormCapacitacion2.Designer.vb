<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCapacitacion2
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
        Me.TextIdCapacitacion = New System.Windows.Forms.TextBox()
        Me.ButtonSeleccionar = New System.Windows.Forms.Button()
        Me.ComboFuncionario = New System.Windows.Forms.ComboBox()
        Me.DateDesde = New System.Windows.Forms.DateTimePicker()
        Me.TextHoras = New System.Windows.Forms.TextBox()
        Me.ButtonCompletar = New System.Windows.Forms.Button()
        Me.ComboEvaluacion2 = New System.Windows.Forms.ComboBox()
        Me.TextCapacitacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ButtonNueva = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboTipo = New System.Windows.Forms.ComboBox()
        Me.ComboEvaluacion1 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.X = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Funcionario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Capacitacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DateHasta = New System.Windows.Forms.DateTimePicker()
        Me.TextNombre = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboFuncionario2 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ButtonTodos = New System.Windows.Forms.Button()
        Me.TextDescripcion = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextArea = New System.Windows.Forms.TextBox()
        Me.ButtonInformes = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(169, 15)
        Me.TextId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(64, 22)
        Me.TextId.TabIndex = 0
        '
        'TextIdCapacitacion
        '
        Me.TextIdCapacitacion.Location = New System.Drawing.Point(277, 49)
        Me.TextIdCapacitacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextIdCapacitacion.Name = "TextIdCapacitacion"
        Me.TextIdCapacitacion.ReadOnly = True
        Me.TextIdCapacitacion.Size = New System.Drawing.Size(64, 22)
        Me.TextIdCapacitacion.TabIndex = 2
        '
        'ButtonSeleccionar
        '
        Me.ButtonSeleccionar.Location = New System.Drawing.Point(169, 47)
        Me.ButtonSeleccionar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonSeleccionar.Name = "ButtonSeleccionar"
        Me.ButtonSeleccionar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonSeleccionar.TabIndex = 1
        Me.ButtonSeleccionar.Text = "Seleccionar"
        Me.ButtonSeleccionar.UseVisualStyleBackColor = True
        '
        'ComboFuncionario
        '
        Me.ComboFuncionario.FormattingEnabled = True
        Me.ComboFuncionario.Location = New System.Drawing.Point(169, 334)
        Me.ComboFuncionario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboFuncionario.Name = "ComboFuncionario"
        Me.ComboFuncionario.Size = New System.Drawing.Size(269, 24)
        Me.ComboFuncionario.TabIndex = 7
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(169, 367)
        Me.DateDesde.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(125, 22)
        Me.DateDesde.TabIndex = 8
        Me.DateDesde.Value = New Date(2013, 7, 4, 0, 0, 0, 0)
        '
        'TextHoras
        '
        Me.TextHoras.Location = New System.Drawing.Point(169, 399)
        Me.TextHoras.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextHoras.Name = "TextHoras"
        Me.TextHoras.Size = New System.Drawing.Size(83, 22)
        Me.TextHoras.TabIndex = 10
        '
        'ButtonCompletar
        '
        Me.ButtonCompletar.Location = New System.Drawing.Point(339, 34)
        Me.ButtonCompletar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonCompletar.Name = "ButtonCompletar"
        Me.ButtonCompletar.Size = New System.Drawing.Size(153, 28)
        Me.ButtonCompletar.TabIndex = 13
        Me.ButtonCompletar.Text = "Completar formulario"
        Me.ButtonCompletar.UseVisualStyleBackColor = True
        '
        'ComboEvaluacion2
        '
        Me.ComboEvaluacion2.FormattingEnabled = True
        Me.ComboEvaluacion2.Location = New System.Drawing.Point(169, 464)
        Me.ComboEvaluacion2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboEvaluacion2.Name = "ComboEvaluacion2"
        Me.ComboEvaluacion2.Size = New System.Drawing.Size(324, 24)
        Me.ComboEvaluacion2.TabIndex = 12
        Me.ComboEvaluacion2.Visible = False
        '
        'TextCapacitacion
        '
        Me.TextCapacitacion.Location = New System.Drawing.Point(169, 81)
        Me.TextCapacitacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextCapacitacion.Multiline = True
        Me.TextCapacitacion.Name = "TextCapacitacion"
        Me.TextCapacitacion.ReadOnly = True
        Me.TextCapacitacion.Size = New System.Drawing.Size(471, 93)
        Me.TextCapacitacion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Capacitación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 337)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Funcionario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 372)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 402)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Horas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 434)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Evualuación personal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 468)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Evaluación de la"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 484)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 17)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "dirección"
        Me.Label8.Visible = False
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Location = New System.Drawing.Point(167, 604)
        Me.ButtonNueva.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(100, 28)
        Me.ButtonNueva.TabIndex = 15
        Me.ButtonNueva.Text = "Nueva"
        Me.ButtonNueva.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(275, 604)
        Me.ButtonGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonGuardar.TabIndex = 14
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(383, 604)
        Me.ButtonEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonEliminar.TabIndex = 16
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 186)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 17)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Tipo de capacitación"
        '
        'ComboTipo
        '
        Me.ComboTipo.FormattingEnabled = True
        Me.ComboTipo.Location = New System.Drawing.Point(169, 182)
        Me.ComboTipo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboTipo.Name = "ComboTipo"
        Me.ComboTipo.Size = New System.Drawing.Size(227, 24)
        Me.ComboTipo.TabIndex = 4
        '
        'ComboEvaluacion1
        '
        Me.ComboEvaluacion1.FormattingEnabled = True
        Me.ComboEvaluacion1.ItemHeight = 16
        Me.ComboEvaluacion1.Location = New System.Drawing.Point(169, 431)
        Me.ComboEvaluacion1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboEvaluacion1.Name = "ComboEvaluacion1"
        Me.ComboEvaluacion1.Size = New System.Drawing.Size(324, 24)
        Me.ComboEvaluacion1.TabIndex = 11
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.X, Me.Id, Me.Fecha, Me.Funcionario, Me.Tipo, Me.Capacitacion})
        Me.DataGridView1.Location = New System.Drawing.Point(669, 47)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(708, 562)
        Me.DataGridView1.TabIndex = 19
        '
        'X
        '
        Me.X.HeaderText = ""
        Me.X.Name = "X"
        Me.X.Text = "c"
        Me.X.UseColumnTextForButtonValue = True
        Me.X.Width = 20
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Funcionario
        '
        Me.Funcionario.HeaderText = "Funcionario"
        Me.Funcionario.Name = "Funcionario"
        Me.Funcionario.Width = 150
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        '
        'Capacitacion
        '
        Me.Capacitacion.HeaderText = "Capacitación"
        Me.Capacitacion.Name = "Capacitacion"
        Me.Capacitacion.Width = 600
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(113, 375)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 17)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "desde"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(304, 375)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 17)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "hasta"
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(356, 367)
        Me.DateHasta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(125, 22)
        Me.DateHasta.TabIndex = 9
        '
        'TextNombre
        '
        Me.TextNombre.Location = New System.Drawing.Point(169, 215)
        Me.TextNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextNombre.Name = "TextNombre"
        Me.TextNombre.Size = New System.Drawing.Size(471, 22)
        Me.TextNombre.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 219)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 17)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Nombre del curso/"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(61, 235)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 17)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "actividad:"
        '
        'ComboFuncionario2
        '
        Me.ComboFuncionario2.FormattingEnabled = True
        Me.ComboFuncionario2.Location = New System.Drawing.Point(813, 15)
        Me.ComboFuncionario2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboFuncionario2.Name = "ComboFuncionario2"
        Me.ComboFuncionario2.Size = New System.Drawing.Size(299, 24)
        Me.ComboFuncionario2.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(665, 23)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(143, 17)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Filtrar por funcionario"
        '
        'ButtonTodos
        '
        Me.ButtonTodos.Location = New System.Drawing.Point(1277, 11)
        Me.ButtonTodos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonTodos.Name = "ButtonTodos"
        Me.ButtonTodos.Size = New System.Drawing.Size(100, 28)
        Me.ButtonTodos.TabIndex = 18
        Me.ButtonTodos.Text = "Todos"
        Me.ButtonTodos.UseVisualStyleBackColor = True
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(169, 247)
        Me.TextDescripcion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(471, 78)
        Me.TextDescripcion.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 271)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 17)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Descripción"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(25, 41)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(310, 17)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Antes de completar el formulario, debe guardar."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.ButtonCompletar)
        Me.GroupBox1.Location = New System.Drawing.Point(161, 497)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(500, 85)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Completar formulario de curso externo al laboratorio"
        '
        'TextArea
        '
        Me.TextArea.Location = New System.Drawing.Point(349, 49)
        Me.TextArea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextArea.Name = "TextArea"
        Me.TextArea.Size = New System.Drawing.Size(64, 22)
        Me.TextArea.TabIndex = 41
        Me.TextArea.Visible = False
        '
        'ButtonInformes
        '
        Me.ButtonInformes.Location = New System.Drawing.Point(491, 604)
        Me.ButtonInformes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonInformes.Name = "ButtonInformes"
        Me.ButtonInformes.Size = New System.Drawing.Size(100, 28)
        Me.ButtonInformes.TabIndex = 42
        Me.ButtonInformes.Text = "Informes"
        Me.ButtonInformes.UseVisualStyleBackColor = True
        '
        'FormCapacitacion2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1393, 642)
        Me.Controls.Add(Me.ButtonInformes)
        Me.Controls.Add(Me.TextArea)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.ButtonTodos)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ComboFuncionario2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TextNombre)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboEvaluacion1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboTipo)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.ButtonNueva)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextCapacitacion)
        Me.Controls.Add(Me.ComboEvaluacion2)
        Me.Controls.Add(Me.TextHoras)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.ComboFuncionario)
        Me.Controls.Add(Me.ButtonSeleccionar)
        Me.Controls.Add(Me.TextIdCapacitacion)
        Me.Controls.Add(Me.TextId)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormCapacitacion2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capacitación y evaluación de eventos RG.ADM 19"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents TextIdCapacitacion As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSeleccionar As System.Windows.Forms.Button
    Friend WithEvents ComboFuncionario As System.Windows.Forms.ComboBox
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextHoras As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCompletar As System.Windows.Forms.Button
    Friend WithEvents ComboEvaluacion2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextCapacitacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ButtonNueva As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ComboEvaluacion1 As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboFuncionario2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ButtonTodos As System.Windows.Forms.Button
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents X As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Funcionario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Capacitacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextArea As System.Windows.Forms.TextBox
    Friend WithEvents ButtonInformes As System.Windows.Forms.Button
End Class
