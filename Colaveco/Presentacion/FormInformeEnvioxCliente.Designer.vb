<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeEnvioxCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInformeEnvioxCliente))
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.TextIdProductor = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProductor = New System.Windows.Forms.Button
        Me.TextProductor = New System.Windows.Forms.TextBox
        Me.RadioFecha = New System.Windows.Forms.RadioButton
        Me.RadioCliente = New System.Windows.Forms.RadioButton
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.RadioFechaCliente = New System.Windows.Forms.RadioButton
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Caja = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Gradilla1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Gradilla2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Gradilla3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Frascos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Agencia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Envio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(536, 34)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(118, 23)
        Me.ButtonListar.TabIndex = 11
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'TextIdProductor
        '
        Me.TextIdProductor.Location = New System.Drawing.Point(155, 59)
        Me.TextIdProductor.Name = "TextIdProductor"
        Me.TextIdProductor.Size = New System.Drawing.Size(68, 20)
        Me.TextIdProductor.TabIndex = 27
        '
        'ButtonBuscarProductor
        '
        Me.ButtonBuscarProductor.Location = New System.Drawing.Point(229, 57)
        Me.ButtonBuscarProductor.Name = "ButtonBuscarProductor"
        Me.ButtonBuscarProductor.Size = New System.Drawing.Size(18, 23)
        Me.ButtonBuscarProductor.TabIndex = 26
        Me.ButtonBuscarProductor.Text = "^"
        Me.ButtonBuscarProductor.UseVisualStyleBackColor = True
        '
        'TextProductor
        '
        Me.TextProductor.Location = New System.Drawing.Point(253, 60)
        Me.TextProductor.Name = "TextProductor"
        Me.TextProductor.Size = New System.Drawing.Size(259, 20)
        Me.TextProductor.TabIndex = 28
        '
        'RadioFecha
        '
        Me.RadioFecha.AutoSize = True
        Me.RadioFecha.Location = New System.Drawing.Point(13, 14)
        Me.RadioFecha.Name = "RadioFecha"
        Me.RadioFecha.Size = New System.Drawing.Size(71, 17)
        Me.RadioFecha.TabIndex = 30
        Me.RadioFecha.TabStop = True
        Me.RadioFecha.Text = "Por fecha"
        Me.RadioFecha.UseVisualStyleBackColor = True
        '
        'RadioCliente
        '
        Me.RadioCliente.AutoSize = True
        Me.RadioCliente.Location = New System.Drawing.Point(13, 37)
        Me.RadioCliente.Name = "RadioCliente"
        Me.RadioCliente.Size = New System.Drawing.Size(75, 17)
        Me.RadioCliente.TabIndex = 31
        Me.RadioCliente.TabStop = True
        Me.RadioCliente.Text = "Por cliente"
        Me.RadioCliente.UseVisualStyleBackColor = True
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(155, 23)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(104, 20)
        Me.DateDesde.TabIndex = 32
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(276, 23)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(104, 20)
        Me.DateHasta.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(152, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(273, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Hasta"
        '
        'RadioFechaCliente
        '
        Me.RadioFechaCliente.AutoSize = True
        Me.RadioFechaCliente.Location = New System.Drawing.Point(13, 60)
        Me.RadioFechaCliente.Name = "RadioFechaCliente"
        Me.RadioFechaCliente.Size = New System.Drawing.Size(113, 17)
        Me.RadioFechaCliente.TabIndex = 36
        Me.RadioFechaCliente.TabStop = True
        Me.RadioFechaCliente.Text = "Por fecha y cliente"
        Me.RadioFechaCliente.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Cliente, Me.Caja, Me.Gradilla1, Me.Gradilla2, Me.Gradilla3, Me.Frascos, Me.Agencia, Me.Envio, Me.Responsable, Me.Observaciones})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 107)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1035, 410)
        Me.DataGridView1.TabIndex = 37
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
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        '
        'Caja
        '
        Me.Caja.HeaderText = "Caja"
        Me.Caja.Name = "Caja"
        '
        'Gradilla1
        '
        Me.Gradilla1.HeaderText = "Gradilla 1"
        Me.Gradilla1.Name = "Gradilla1"
        '
        'Gradilla2
        '
        Me.Gradilla2.HeaderText = "Gradilla 2"
        Me.Gradilla2.Name = "Gradilla2"
        '
        'Gradilla3
        '
        Me.Gradilla3.HeaderText = "Gradilla 3"
        Me.Gradilla3.Name = "Gradilla3"
        '
        'Frascos
        '
        Me.Frascos.HeaderText = "Frascos"
        Me.Frascos.Name = "Frascos"
        '
        'Agencia
        '
        Me.Agencia.HeaderText = "Agencia"
        Me.Agencia.Name = "Agencia"
        '
        'Envio
        '
        Me.Envio.HeaderText = "Envio"
        Me.Envio.Name = "Envio"
        '
        'Responsable
        '
        Me.Responsable.HeaderText = "Responsable"
        Me.Responsable.Name = "Responsable"
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        '
        'FormInformeEnvioxCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1060, 529)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormInformeEnvioxCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envíos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents TextIdProductor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProductor As System.Windows.Forms.Button
    Friend WithEvents TextProductor As System.Windows.Forms.TextBox
    Friend WithEvents RadioFecha As System.Windows.Forms.RadioButton
    Friend WithEvents RadioCliente As System.Windows.Forms.RadioButton
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioFechaCliente As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Caja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gradilla1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gradilla2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gradilla3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Frascos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Envio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Responsable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
