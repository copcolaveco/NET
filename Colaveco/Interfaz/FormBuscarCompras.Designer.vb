<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarCompras
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Seleccionar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.DateTimeDesde = New System.Windows.Forms.DateTimePicker
        Me.DateTimeHasta = New System.Windows.Forms.DateTimePicker
        Me.TextProveedor = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProveedor = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextIdProveedor = New System.Windows.Forms.TextBox
        Me.TextNumero = New System.Windows.Forms.TextBox
        Me.RadioFechas = New System.Windows.Forms.RadioButton
        Me.RadioProveedor = New System.Windows.Forms.RadioButton
        Me.RadioNumero = New System.Windows.Forms.RadioButton
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Proveedor, Me.Seleccionar})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 120)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(506, 423)
        Me.DataGridView1.TabIndex = 26
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Width = 80
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 70
        '
        'Proveedor
        '
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.Width = 250
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = ""
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Text = "Seleccionar"
        Me.Seleccionar.UseColumnTextForButtonValue = True
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(446, 91)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscar.TabIndex = 25
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'DateTimeDesde
        '
        Me.DateTimeDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimeDesde.Location = New System.Drawing.Point(114, 84)
        Me.DateTimeDesde.Name = "DateTimeDesde"
        Me.DateTimeDesde.Size = New System.Drawing.Size(92, 20)
        Me.DateTimeDesde.TabIndex = 24
        '
        'DateTimeHasta
        '
        Me.DateTimeHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimeHasta.Location = New System.Drawing.Point(212, 84)
        Me.DateTimeHasta.Name = "DateTimeHasta"
        Me.DateTimeHasta.Size = New System.Drawing.Size(92, 20)
        Me.DateTimeHasta.TabIndex = 23
        '
        'TextProveedor
        '
        Me.TextProveedor.Location = New System.Drawing.Point(204, 58)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.Size = New System.Drawing.Size(258, 20)
        Me.TextProveedor.TabIndex = 22
        '
        'ButtonBuscarProveedor
        '
        Me.ButtonBuscarProveedor.Location = New System.Drawing.Point(177, 59)
        Me.ButtonBuscarProveedor.Name = "ButtonBuscarProveedor"
        Me.ButtonBuscarProveedor.Size = New System.Drawing.Size(21, 19)
        Me.ButtonBuscarProveedor.TabIndex = 21
        Me.ButtonBuscarProveedor.Text = "^"
        Me.ButtonBuscarProveedor.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Buscar compra por:"
        '
        'TextIdProveedor
        '
        Me.TextIdProveedor.Location = New System.Drawing.Point(114, 57)
        Me.TextIdProveedor.Name = "TextIdProveedor"
        Me.TextIdProveedor.Size = New System.Drawing.Size(57, 20)
        Me.TextIdProveedor.TabIndex = 19
        '
        'TextNumero
        '
        Me.TextNumero.Location = New System.Drawing.Point(114, 31)
        Me.TextNumero.Name = "TextNumero"
        Me.TextNumero.Size = New System.Drawing.Size(78, 20)
        Me.TextNumero.TabIndex = 18
        '
        'RadioFechas
        '
        Me.RadioFechas.AutoSize = True
        Me.RadioFechas.Location = New System.Drawing.Point(15, 86)
        Me.RadioFechas.Name = "RadioFechas"
        Me.RadioFechas.Size = New System.Drawing.Size(60, 17)
        Me.RadioFechas.TabIndex = 17
        Me.RadioFechas.TabStop = True
        Me.RadioFechas.Text = "Fechas"
        Me.RadioFechas.UseVisualStyleBackColor = True
        '
        'RadioProveedor
        '
        Me.RadioProveedor.AutoSize = True
        Me.RadioProveedor.Location = New System.Drawing.Point(15, 59)
        Me.RadioProveedor.Name = "RadioProveedor"
        Me.RadioProveedor.Size = New System.Drawing.Size(74, 17)
        Me.RadioProveedor.TabIndex = 16
        Me.RadioProveedor.TabStop = True
        Me.RadioProveedor.Text = "Proveedor"
        Me.RadioProveedor.UseVisualStyleBackColor = True
        '
        'RadioNumero
        '
        Me.RadioNumero.AutoSize = True
        Me.RadioNumero.Location = New System.Drawing.Point(15, 32)
        Me.RadioNumero.Name = "RadioNumero"
        Me.RadioNumero.Size = New System.Drawing.Size(62, 17)
        Me.RadioNumero.TabIndex = 15
        Me.RadioNumero.TabStop = True
        Me.RadioNumero.Text = "Número"
        Me.RadioNumero.UseVisualStyleBackColor = True
        '
        'FormBuscarCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 552)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.DateTimeDesde)
        Me.Controls.Add(Me.DateTimeHasta)
        Me.Controls.Add(Me.TextProveedor)
        Me.Controls.Add(Me.ButtonBuscarProveedor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextIdProveedor)
        Me.Controls.Add(Me.TextNumero)
        Me.Controls.Add(Me.RadioFechas)
        Me.Controls.Add(Me.RadioProveedor)
        Me.Controls.Add(Me.RadioNumero)
        Me.Name = "FormBuscarCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Compras"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents DateTimeDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextProveedor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextIdProveedor As System.Windows.Forms.TextBox
    Friend WithEvents TextNumero As System.Windows.Forms.TextBox
    Friend WithEvents RadioFechas As System.Windows.Forms.RadioButton
    Friend WithEvents RadioProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNumero As System.Windows.Forms.RadioButton
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewButtonColumn
End Class
