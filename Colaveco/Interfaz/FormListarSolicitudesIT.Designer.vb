<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListarSolicitudesIT
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ButtonListarTodas = New System.Windows.Forms.Button
        Me.ButtonListar = New System.Windows.Forms.Button
        Me.ComboListarUsuario = New System.Windows.Forms.ComboBox
        Me.ComboListarEstado = New System.Windows.Forms.ComboBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Solicitante = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Prioridad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cambiar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.ComboUsuario = New System.Windows.Forms.ComboBox
        Me.ComboPrioridad = New System.Windows.Forms.ComboBox
        Me.TextDescripcion = New System.Windows.Forms.TextBox
        Me.DateFecha = New System.Windows.Forms.DateTimePicker
        Me.TextId = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(555, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Solicitante"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(428, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Estado"
        '
        'ButtonListarTodas
        '
        Me.ButtonListarTodas.Location = New System.Drawing.Point(883, 26)
        Me.ButtonListarTodas.Name = "ButtonListarTodas"
        Me.ButtonListarTodas.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListarTodas.TabIndex = 23
        Me.ButtonListarTodas.Text = "Listar todas"
        Me.ButtonListarTodas.UseVisualStyleBackColor = True
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(685, 26)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 22
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'ComboListarUsuario
        '
        Me.ComboListarUsuario.FormattingEnabled = True
        Me.ComboListarUsuario.Location = New System.Drawing.Point(558, 28)
        Me.ComboListarUsuario.Name = "ComboListarUsuario"
        Me.ComboListarUsuario.Size = New System.Drawing.Size(121, 21)
        Me.ComboListarUsuario.TabIndex = 21
        '
        'ComboListarEstado
        '
        Me.ComboListarEstado.FormattingEnabled = True
        Me.ComboListarEstado.Location = New System.Drawing.Point(431, 28)
        Me.ComboListarEstado.Name = "ComboListarEstado"
        Me.ComboListarEstado.Size = New System.Drawing.Size(121, 21)
        Me.ComboListarEstado.TabIndex = 20
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Solicitante, Me.Prioridad, Me.Estado, Me.Cambiar})
        Me.DataGridView1.Location = New System.Drawing.Point(431, 55)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(527, 427)
        Me.DataGridView1.TabIndex = 19
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
        Me.Fecha.Width = 70
        '
        'Solicitante
        '
        Me.Solicitante.HeaderText = "Solicitante"
        Me.Solicitante.Name = "Solicitante"
        Me.Solicitante.Width = 150
        '
        'Prioridad
        '
        Me.Prioridad.HeaderText = "Prioridad"
        Me.Prioridad.Name = "Prioridad"
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        '
        'Cambiar
        '
        Me.Cambiar.HeaderText = "Cambiar"
        Me.Cambiar.Name = "Cambiar"
        Me.Cambiar.UseColumnTextForButtonValue = True
        '
        'ComboUsuario
        '
        Me.ComboUsuario.FormattingEnabled = True
        Me.ComboUsuario.Location = New System.Drawing.Point(73, 396)
        Me.ComboUsuario.Name = "ComboUsuario"
        Me.ComboUsuario.Size = New System.Drawing.Size(223, 21)
        Me.ComboUsuario.TabIndex = 35
        '
        'ComboPrioridad
        '
        Me.ComboPrioridad.FormattingEnabled = True
        Me.ComboPrioridad.Location = New System.Drawing.Point(73, 62)
        Me.ComboPrioridad.Name = "ComboPrioridad"
        Me.ComboPrioridad.Size = New System.Drawing.Size(121, 21)
        Me.ComboPrioridad.TabIndex = 34
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(14, 108)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(399, 278)
        Me.TextDescripcion.TabIndex = 33
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(73, 36)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 32
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(73, 10)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(55, 20)
        Me.TextId.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Prioridad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 399)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Solicitante"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Id"
        '
        'FormListarSolicitudesIT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 494)
        Me.Controls.Add(Me.ComboUsuario)
        Me.Controls.Add(Me.ComboPrioridad)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.DateFecha)
        Me.Controls.Add(Me.TextId)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ButtonListarTodas)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.ComboListarUsuario)
        Me.Controls.Add(Me.ComboListarEstado)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormListarSolicitudesIT"
        Me.Text = "Solicitudes IT"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonListarTodas As System.Windows.Forms.Button
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents ComboListarUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents ComboListarEstado As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Solicitante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prioridad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cambiar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ComboUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents ComboPrioridad As System.Windows.Forms.ComboBox
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
