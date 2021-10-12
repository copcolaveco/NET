<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarActas
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
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComboGrupo = New System.Windows.Forms.ComboBox
        Me.RadioFecha = New System.Windows.Forms.RadioButton
        Me.RadioGrupo = New System.Windows.Forms.RadioButton
        Me.DateHasta = New System.Windows.Forms.DateTimePicker
        Me.DateDesde = New System.Windows.Forms.DateTimePicker
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.RadioFechaGrupo = New System.Windows.Forms.RadioButton
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Numero, Me.Fecha, Me.Grupo})
        Me.DataGridView1.Location = New System.Drawing.Point(334, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(355, 458)
        Me.DataGridView1.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Numero
        '
        Me.Numero.HeaderText = "Número"
        Me.Numero.Name = "Numero"
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        '
        'Grupo
        '
        Me.Grupo.HeaderText = "Grupo"
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Width = 150
        '
        'ComboGrupo
        '
        Me.ComboGrupo.FormattingEnabled = True
        Me.ComboGrupo.Location = New System.Drawing.Point(94, 38)
        Me.ComboGrupo.Name = "ComboGrupo"
        Me.ComboGrupo.Size = New System.Drawing.Size(220, 21)
        Me.ComboGrupo.TabIndex = 1
        '
        'RadioFecha
        '
        Me.RadioFecha.AutoSize = True
        Me.RadioFecha.Location = New System.Drawing.Point(12, 12)
        Me.RadioFecha.Name = "RadioFecha"
        Me.RadioFecha.Size = New System.Drawing.Size(76, 17)
        Me.RadioFecha.TabIndex = 2
        Me.RadioFecha.TabStop = True
        Me.RadioFecha.Text = "Por fechas"
        Me.RadioFecha.UseVisualStyleBackColor = True
        '
        'RadioGrupo
        '
        Me.RadioGrupo.AutoSize = True
        Me.RadioGrupo.Location = New System.Drawing.Point(12, 42)
        Me.RadioGrupo.Name = "RadioGrupo"
        Me.RadioGrupo.Size = New System.Drawing.Size(71, 17)
        Me.RadioGrupo.TabIndex = 3
        Me.RadioGrupo.TabStop = True
        Me.RadioGrupo.Text = "Por grupo"
        Me.RadioGrupo.UseVisualStyleBackColor = True
        '
        'DateHasta
        '
        Me.DateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateHasta.Location = New System.Drawing.Point(207, 12)
        Me.DateHasta.Name = "DateHasta"
        Me.DateHasta.Size = New System.Drawing.Size(107, 20)
        Me.DateHasta.TabIndex = 5
        '
        'DateDesde
        '
        Me.DateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDesde.Location = New System.Drawing.Point(94, 12)
        Me.DateDesde.Name = "DateDesde"
        Me.DateDesde.Size = New System.Drawing.Size(107, 20)
        Me.DateDesde.TabIndex = 6
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(239, 71)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuscar.TabIndex = 7
        Me.ButtonBuscar.Text = "Buscar"
        Me.ButtonBuscar.UseVisualStyleBackColor = True
        '
        'RadioFechaGrupo
        '
        Me.RadioFechaGrupo.AutoSize = True
        Me.RadioFechaGrupo.Location = New System.Drawing.Point(12, 74)
        Me.RadioFechaGrupo.Name = "RadioFechaGrupo"
        Me.RadioFechaGrupo.Size = New System.Drawing.Size(109, 17)
        Me.RadioFechaGrupo.TabIndex = 8
        Me.RadioFechaGrupo.TabStop = True
        Me.RadioFechaGrupo.Text = "Por fecha y grupo"
        Me.RadioFechaGrupo.UseVisualStyleBackColor = True
        '
        'FormBuscarActas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 482)
        Me.Controls.Add(Me.RadioFechaGrupo)
        Me.Controls.Add(Me.ButtonBuscar)
        Me.Controls.Add(Me.DateDesde)
        Me.Controls.Add(Me.DateHasta)
        Me.Controls.Add(Me.RadioGrupo)
        Me.Controls.Add(Me.RadioFecha)
        Me.Controls.Add(Me.ComboGrupo)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormBuscarActas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Actas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents RadioFecha As System.Windows.Forms.RadioButton
    Friend WithEvents RadioGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents DateHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadioFechaGrupo As System.Windows.Forms.RadioButton
End Class
