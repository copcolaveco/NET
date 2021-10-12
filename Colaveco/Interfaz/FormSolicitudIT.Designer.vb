<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSolicitudIT
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextId = New System.Windows.Forms.TextBox()
        Me.DateFecha = New System.Windows.Forms.DateTimePicker()
        Me.TextDescripcion = New System.Windows.Forms.TextBox()
        Me.ComboPrioridad = New System.Windows.Forms.ComboBox()
        Me.ComboUsuario = New System.Windows.Forms.ComboBox()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ButtonNueva = New System.Windows.Forms.Button()
        Me.ComboListarEstado = New System.Windows.Forms.ComboBox()
        Me.ComboListarUsuario = New System.Windows.Forms.ComboBox()
        Me.ButtonListar = New System.Windows.Forms.Button()
        Me.ButtonListarTodas = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CheckAutorizada = New System.Windows.Forms.CheckBox()
        Me.CheckValidado = New System.Windows.Forms.CheckBox()
        Me.DateValidacion = New System.Windows.Forms.DateTimePicker()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboAutoriza = New System.Windows.Forms.ComboBox()
        Me.ComboValida = New System.Windows.Forms.ComboBox()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Solicitante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prioridad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.A = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.V = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Descripción"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 331)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Solicitante"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Prioridad"
        '
        'TextId
        '
        Me.TextId.Location = New System.Drawing.Point(126, 6)
        Me.TextId.Name = "TextId"
        Me.TextId.ReadOnly = True
        Me.TextId.Size = New System.Drawing.Size(55, 20)
        Me.TextId.TabIndex = 5
        '
        'DateFecha
        '
        Me.DateFecha.Enabled = False
        Me.DateFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateFecha.Location = New System.Drawing.Point(126, 32)
        Me.DateFecha.Name = "DateFecha"
        Me.DateFecha.Size = New System.Drawing.Size(100, 20)
        Me.DateFecha.TabIndex = 6
        '
        'TextDescripcion
        '
        Me.TextDescripcion.Location = New System.Drawing.Point(126, 85)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(359, 237)
        Me.TextDescripcion.TabIndex = 7
        '
        'ComboPrioridad
        '
        Me.ComboPrioridad.FormattingEnabled = True
        Me.ComboPrioridad.Location = New System.Drawing.Point(126, 58)
        Me.ComboPrioridad.Name = "ComboPrioridad"
        Me.ComboPrioridad.Size = New System.Drawing.Size(121, 21)
        Me.ComboPrioridad.TabIndex = 8
        '
        'ComboUsuario
        '
        Me.ComboUsuario.FormattingEnabled = True
        Me.ComboUsuario.Location = New System.Drawing.Point(126, 328)
        Me.ComboUsuario.Name = "ComboUsuario"
        Me.ComboUsuario.Size = New System.Drawing.Size(223, 21)
        Me.ComboUsuario.TabIndex = 9
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(208, 535)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 10
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Solicitante, Me.Prioridad, Me.A, Me.V, Me.Estado})
        Me.DataGridView1.Location = New System.Drawing.Point(492, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(515, 469)
        Me.DataGridView1.TabIndex = 11
        '
        'ButtonNueva
        '
        Me.ButtonNueva.Location = New System.Drawing.Point(127, 535)
        Me.ButtonNueva.Name = "ButtonNueva"
        Me.ButtonNueva.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNueva.TabIndex = 12
        Me.ButtonNueva.Text = "Nueva"
        Me.ButtonNueva.UseVisualStyleBackColor = True
        '
        'ComboListarEstado
        '
        Me.ComboListarEstado.FormattingEnabled = True
        Me.ComboListarEstado.Location = New System.Drawing.Point(492, 31)
        Me.ComboListarEstado.Name = "ComboListarEstado"
        Me.ComboListarEstado.Size = New System.Drawing.Size(121, 21)
        Me.ComboListarEstado.TabIndex = 13
        '
        'ComboListarUsuario
        '
        Me.ComboListarUsuario.FormattingEnabled = True
        Me.ComboListarUsuario.Location = New System.Drawing.Point(619, 31)
        Me.ComboListarUsuario.Name = "ComboListarUsuario"
        Me.ComboListarUsuario.Size = New System.Drawing.Size(121, 21)
        Me.ComboListarUsuario.TabIndex = 14
        '
        'ButtonListar
        '
        Me.ButtonListar.Location = New System.Drawing.Point(746, 29)
        Me.ButtonListar.Name = "ButtonListar"
        Me.ButtonListar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListar.TabIndex = 15
        Me.ButtonListar.Text = "Listar"
        Me.ButtonListar.UseVisualStyleBackColor = True
        '
        'ButtonListarTodas
        '
        Me.ButtonListarTodas.Location = New System.Drawing.Point(844, 29)
        Me.ButtonListarTodas.Name = "ButtonListarTodas"
        Me.ButtonListarTodas.Size = New System.Drawing.Size(75, 23)
        Me.ButtonListarTodas.TabIndex = 16
        Me.ButtonListarTodas.Text = "Listar todas"
        Me.ButtonListarTodas.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(489, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Estado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(616, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Solicitante"
        '
        'CheckAutorizada
        '
        Me.CheckAutorizada.AutoSize = True
        Me.CheckAutorizada.Location = New System.Drawing.Point(127, 363)
        Me.CheckAutorizada.Name = "CheckAutorizada"
        Me.CheckAutorizada.Size = New System.Drawing.Size(76, 17)
        Me.CheckAutorizada.TabIndex = 19
        Me.CheckAutorizada.Text = "Autorizada"
        Me.CheckAutorizada.UseVisualStyleBackColor = True
        '
        'CheckValidado
        '
        Me.CheckValidado.AutoSize = True
        Me.CheckValidado.Location = New System.Drawing.Point(127, 392)
        Me.CheckValidado.Name = "CheckValidado"
        Me.CheckValidado.Size = New System.Drawing.Size(67, 17)
        Me.CheckValidado.TabIndex = 20
        Me.CheckValidado.Text = "Validado"
        Me.CheckValidado.UseVisualStyleBackColor = True
        '
        'DateValidacion
        '
        Me.DateValidacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateValidacion.Location = New System.Drawing.Point(391, 387)
        Me.DateValidacion.Name = "DateValidacion"
        Me.DateValidacion.Size = New System.Drawing.Size(94, 20)
        Me.DateValidacion.TabIndex = 21
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Location = New System.Drawing.Point(127, 415)
        Me.TextObservaciones.Multiline = True
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(359, 114)
        Me.TextObservaciones.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = ""
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 428)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Observaciones"
        '
        'ComboAutoriza
        '
        Me.ComboAutoriza.Enabled = False
        Me.ComboAutoriza.FormattingEnabled = True
        Me.ComboAutoriza.Location = New System.Drawing.Point(208, 361)
        Me.ComboAutoriza.Name = "ComboAutoriza"
        Me.ComboAutoriza.Size = New System.Drawing.Size(141, 21)
        Me.ComboAutoriza.TabIndex = 24
        '
        'ComboValida
        '
        Me.ComboValida.Enabled = False
        Me.ComboValida.FormattingEnabled = True
        Me.ComboValida.Location = New System.Drawing.Point(208, 388)
        Me.ComboValida.Name = "ComboValida"
        Me.ComboValida.Size = New System.Drawing.Size(141, 21)
        Me.ComboValida.TabIndex = 25
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
        'A
        '
        Me.A.HeaderText = "A"
        Me.A.Name = "A"
        Me.A.Width = 40
        '
        'V
        '
        Me.V.HeaderText = "V"
        Me.V.Name = "V"
        Me.V.Width = 40
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        '
        'FormSolicitudIT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 575)
        Me.Controls.Add(Me.ComboValida)
        Me.Controls.Add(Me.ComboAutoriza)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextObservaciones)
        Me.Controls.Add(Me.DateValidacion)
        Me.Controls.Add(Me.CheckValidado)
        Me.Controls.Add(Me.CheckAutorizada)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ButtonListarTodas)
        Me.Controls.Add(Me.ButtonListar)
        Me.Controls.Add(Me.ComboListarUsuario)
        Me.Controls.Add(Me.ComboListarEstado)
        Me.Controls.Add(Me.ButtonNueva)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ButtonGuardar)
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
        Me.Name = "FormSolicitudIT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitudes de cambios del software - RG.CC 61 ( v 02 - 28/05/2018)"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextId As System.Windows.Forms.TextBox
    Friend WithEvents DateFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents ComboPrioridad As System.Windows.Forms.ComboBox
    Friend WithEvents ComboUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonNueva As System.Windows.Forms.Button
    Friend WithEvents ComboListarEstado As System.Windows.Forms.ComboBox
    Friend WithEvents ComboListarUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonListar As System.Windows.Forms.Button
    Friend WithEvents ButtonListarTodas As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CheckAutorizada As System.Windows.Forms.CheckBox
    Friend WithEvents CheckValidado As System.Windows.Forms.CheckBox
    Friend WithEvents DateValidacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Solicitante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prioridad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents A As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboAutoriza As System.Windows.Forms.ComboBox
    Friend WithEvents ComboValida As System.Windows.Forms.ComboBox
End Class
