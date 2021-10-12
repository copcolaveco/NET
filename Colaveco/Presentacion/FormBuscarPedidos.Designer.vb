<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarPedidos
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
        Me.RadioFechaCliente = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.RadioCliente = New System.Windows.Forms.RadioButton
        Me.RadioFecha = New System.Windows.Forms.RadioButton
        Me.TextIdProductor = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProductor = New System.Windows.Forms.Button
        Me.TextProductor = New System.Windows.Forms.TextBox
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Agencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RC_Compos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Agua = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sangre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Esteriles = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Otros = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadioFechaCliente
        '
        Me.RadioFechaCliente.AutoSize = True
        Me.RadioFechaCliente.Location = New System.Drawing.Point(12, 58)
        Me.RadioFechaCliente.Name = "RadioFechaCliente"
        Me.RadioFechaCliente.Size = New System.Drawing.Size(113, 17)
        Me.RadioFechaCliente.TabIndex = 47
        Me.RadioFechaCliente.TabStop = True
        Me.RadioFechaCliente.Text = "Por fecha y cliente"
        Me.RadioFechaCliente.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(272, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(151, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Desde"
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(275, 21)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(104, 20)
        Me.DateHasta.TabIndex = 44
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(154, 21)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(104, 20)
        Me.DateDesde.TabIndex = 43
        '
        'RadioCliente
        '
        Me.RadioCliente.AutoSize = True
        Me.RadioCliente.Location = New System.Drawing.Point(12, 35)
        Me.RadioCliente.Name = "RadioCliente"
        Me.RadioCliente.Size = New System.Drawing.Size(75, 17)
        Me.RadioCliente.TabIndex = 42
        Me.RadioCliente.TabStop = True
        Me.RadioCliente.Text = "Por cliente"
        Me.RadioCliente.UseVisualStyleBackColor = True
        '
        'RadioFecha
        '
        Me.RadioFecha.AutoSize = True
        Me.RadioFecha.Location = New System.Drawing.Point(12, 12)
        Me.RadioFecha.Name = "RadioFecha"
        Me.RadioFecha.Size = New System.Drawing.Size(71, 17)
        Me.RadioFecha.TabIndex = 41
        Me.RadioFecha.TabStop = True
        Me.RadioFecha.Text = "Por fecha"
        Me.RadioFecha.UseVisualStyleBackColor = True
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(154, 57)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(68, 20)
        Me.TextIdProductor.TabIndex = 39
        '
        'ButtonBuscarProductor
        '
        Me.ButtonBuscarProductor.Location = New System.Drawing.Point(228, 55)
        Me.ButtonBuscarProductor.Name = "ButtonBuscarProductor"
        Me.ButtonBuscarProductor.Size = New System.Drawing.Size(18, 23)
        Me.ButtonBuscarProductor.TabIndex = 38
        Me.ButtonBuscarProductor.Text = "^"
        Me.ButtonBuscarProductor.UseVisualStyleBackColor = True
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(252, 58)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(259, 20)
        Me.TextProductor.TabIndex = 40
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(535, 32)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(118, 23)
        Me.ButtonListar.TabIndex = 37
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Cliente, Me.Direccion, Me.Telefono, Me.Agencia, Me.Responsable, Me.RC_Compos, Me.Agua, Me.Sangre, Me.Esteriles, Me.Otros, Me.Observaciones})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 84)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(979, 350)
        Me.DataGridView1.TabIndex = 48
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Width = 60
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Width = 200
        '
        'Direccion
        '
        Me.Direccion.HeaderText = "Dirección"
        Me.Direccion.Name = "Direccion"
        '
        'Telefono
        '
        Me.Telefono.HeaderText = "Teléfono"
        Me.Telefono.Name = "Telefono"
        '
        'Agencia
        '
        Me.Agencia.HeaderText = "Agencia"
        Me.Agencia.Name = "Agencia"
        '
        'Responsable
        '
        Me.Responsable.HeaderText = "Responsable"
        Me.Responsable.Name = "Responsable"
        '
        'RC_Compos
        '
        Me.RC_Compos.HeaderText = "RC_Compos"
        Me.RC_Compos.Name = "RC_Compos"
        '
        'Agua
        '
        Me.Agua.HeaderText = "Agua"
        Me.Agua.Name = "Agua"
        '
        'Sangre
        '
        Me.Sangre.HeaderText = "Sangre"
        Me.Sangre.Name = "Sangre"
        '
        'Esteriles
        '
        Me.Esteriles.HeaderText = "Estériles"
        Me.Esteriles.Name = "Esteriles"
        '
        'Otros
        '
        Me.Otros.HeaderText = "Otros"
        Me.Otros.Name = "Otros"
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        '
        'FormBuscarPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 448)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.RadioFechaCliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.RadioCliente)
        Me.Controls.Add(Me.RadioFecha)
        Me.Controls.Add(Me.TextIdProductor)
        Me.Controls.Add(Me.ButtonBuscarProductor)
        Me.Controls.Add(Me.TextProductor)
        Me.Controls.Add(Me.ButtonListar)
        Me.Name = "FormBuscarPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar pedidos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioFechaCliente As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioCliente As System.Windows.Forms.RadioButton
    Friend WithEvents RadioFecha As System.Windows.Forms.RadioButton
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProductor As System.Windows.Forms.Button
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Telefono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RC_Compos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agua As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sangre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Esteriles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Otros As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
