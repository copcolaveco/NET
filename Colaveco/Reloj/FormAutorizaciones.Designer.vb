<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAutorizaciones
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.ComboNombre = New System.Windows.Forms.ComboBox()
        Me.ComboTipo = New System.Windows.Forms.ComboBox()
        Me.TextDetalle = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComboAutoriza = New System.Windows.Forms.ComboBox()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.TextEmail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ButtonNoAutorizar = New System.Windows.Forms.Button()
        Me.ButtonEliminar = New System.Windows.Forms.Button()
        Me.DateFechaEvento = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.filtros = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.desde = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.hasta = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbxUsuario = New System.Windows.Forms.ComboBox()
        Me.cbxSinFiltros = New System.Windows.Forms.CheckBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(127, 18)
        Me.TextId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(71, 22)
        Me.TextId.TabIndex = 0
        '
        'DateFecha
        '
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(127, 50)
        Me.DateFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(132, 22)
        Me.DateFecha.TabIndex = 1
        '
        'ComboNombre
        '
        Me.ComboNombre.FormattingEnabled = True
        Me.ComboNombre.Location = New System.Drawing.Point(127, 82)
        Me.ComboNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboNombre.Name = "ComboNombre"
        Me.ComboNombre.Size = New System.Drawing.Size(229, 24)
        Me.ComboNombre.TabIndex = 2
        '
        'ComboTipo
        '
        Me.ComboTipo.FormattingEnabled = True
        Me.ComboTipo.Location = New System.Drawing.Point(127, 116)
        Me.ComboTipo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboTipo.Name = "ComboTipo"
        Me.ComboTipo.Size = New System.Drawing.Size(229, 24)
        Me.ComboTipo.TabIndex = 3
        '
        'TextDetalle
        '
        Me.TextDetalle.Location = New System.Drawing.Point(127, 181)
        Me.TextDetalle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextDetalle.Multiline = True
        Me.TextDetalle.Name = "TextDetalle"
        Me.TextDetalle.Size = New System.Drawing.Size(436, 157)
        Me.TextDetalle.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(97, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 58)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 86)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(81, 119)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tipo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(65, 185)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Detalle"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Nombre, Me.Tipo, Me.Detalle})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridView1.Location = New System.Drawing.Point(572, 116)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(796, 460)
        Me.DataGridView1.TabIndex = 10
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
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 150
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        '
        'Detalle
        '
        Me.Detalle.HeaderText = "Detalle"
        Me.Detalle.Name = "Detalle"
        '
        'ComboAutoriza
        '
        Me.ComboAutoriza.FormattingEnabled = True
        Me.ComboAutoriza.Location = New System.Drawing.Point(127, 378)
        Me.ComboAutoriza.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboAutoriza.Name = "ComboAutoriza"
        Me.ComboAutoriza.Size = New System.Drawing.Size(229, 24)
        Me.ComboAutoriza.TabIndex = 11
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(127, 411)
        Me.TextObservaciones.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(436, 131)
        Me.TextObservaciones.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(59, 388)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Autoriza"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 427)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Observaciones"
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(127, 548)
        Me.ButtonGuardar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonGuardar.TabIndex = 15
        Me.ButtonGuardar.Text = "Autorizar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'TextEmail
        '
        Me.TextEmail.Location = New System.Drawing.Point(127, 346)
        Me.TextEmail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextEmail.Name = "TextEmail"
        Me.TextEmail.Size = New System.Drawing.Size(436, 22)
        Me.TextEmail.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(76, 350)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 17)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Email"
        '
        'ButtonNoAutorizar
        '
        Me.ButtonNoAutorizar.Location = New System.Drawing.Point(235, 548)
        Me.ButtonNoAutorizar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonNoAutorizar.Name = "ButtonNoAutorizar"
        Me.ButtonNoAutorizar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonNoAutorizar.TabIndex = 18
        Me.ButtonNoAutorizar.Text = "No autorizar"
        Me.ButtonNoAutorizar.UseVisualStyleBackColor = True
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(464, 548)
        Me.ButtonEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(100, 28)
        Me.ButtonEliminar.TabIndex = 19
        Me.ButtonEliminar.Text = "Eliminar"
        Me.ButtonEliminar.UseVisualStyleBackColor = True
        '
        'DateFechaEvento
        '
        Me.DateFechaEvento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFechaEvento.Location = New System.Drawing.Point(127, 149)
        Me.DateFechaEvento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DateFechaEvento.Name = "DateFechaEvento"
        Me.DateFechaEvento.Size = New System.Drawing.Size(132, 22)
        Me.DateFechaEvento.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(-1, 156)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 17)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Fecha del evento"
        '
        'filtros
        '
        Me.filtros.AutoSize = True
        Me.filtros.Location = New System.Drawing.Point(569, 23)
        Me.filtros.Name = "filtros"
        Me.filtros.Size = New System.Drawing.Size(46, 17)
        Me.filtros.TabIndex = 23
        Me.filtros.Text = "Filtros"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(569, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 17)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Desde"
        '
        'desde
        '
        Me.desde.Location = New System.Drawing.Point(635, 53)
        Me.desde.Name = "desde"
        Me.desde.Size = New System.Drawing.Size(115, 22)
        Me.desde.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(777, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 17)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Hasta"
        '
        'hasta
        '
        Me.hasta.Location = New System.Drawing.Point(840, 53)
        Me.hasta.Name = "hasta"
        Me.hasta.Size = New System.Drawing.Size(115, 22)
        Me.hasta.TabIndex = 27
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(980, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 17)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Usuario"
        '
        'cbxUsuario
        '
        Me.cbxUsuario.FormattingEnabled = True
        Me.cbxUsuario.Location = New System.Drawing.Point(1043, 50)
        Me.cbxUsuario.Name = "cbxUsuario"
        Me.cbxUsuario.Size = New System.Drawing.Size(121, 24)
        Me.cbxUsuario.TabIndex = 29
        '
        'cbxSinFiltros
        '
        Me.cbxSinFiltros.AutoSize = True
        Me.cbxSinFiltros.Location = New System.Drawing.Point(1181, 50)
        Me.cbxSinFiltros.Name = "cbxSinFiltros"
        Me.cbxSinFiltros.Size = New System.Drawing.Size(88, 21)
        Me.cbxSinFiltros.TabIndex = 30
        Me.cbxSinFiltros.Text = "Sin filtros"
        Me.cbxSinFiltros.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(1215, 80)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 31
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Image = Global.Colaveco.My.Resources.Resources.excel
        Me.btnExcel.Location = New System.Drawing.Point(1293, 80)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnExcel.TabIndex = 32
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'FormAutorizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1381, 608)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.cbxSinFiltros)
        Me.Controls.Add(Me.cbxUsuario)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.hasta)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.desde)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.filtros)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DateFechaEvento)
        Me.Controls.Add(Me.ButtonEliminar)
        Me.Controls.Add(Me.ButtonNoAutorizar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextEmail)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.ComboAutoriza)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextDetalle)
        Me.Controls.Add(Me.ComboTipo)
        Me.Controls.Add(Me.ComboNombre)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormAutorizaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedido de autorizaciones"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboNombre As System.Windows.Forms.ComboBox
    Friend WithEvents ComboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents TextDetalle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboAutoriza As System.Windows.Forms.ComboBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ButtonNoAutorizar As System.Windows.Forms.Button
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents DateFechaEvento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents filtros As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents desde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents hasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbxUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents cbxSinFiltros As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
End Class
