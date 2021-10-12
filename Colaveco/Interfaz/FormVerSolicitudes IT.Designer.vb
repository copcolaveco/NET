<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVerSolicitudes_IT
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RadioTodas = New System.Windows.Forms.RadioButton()
        Me.RadioPendientes = New System.Windows.Forms.RadioButton()
        Me.RadioFinalizadas = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RadioProceso = New System.Windows.Forms.RadioButton()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Autorizado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Solicita = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prioridad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cambiar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.AgregarObservaciones = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadioTodas
        '
        Me.RadioTodas.AutoSize = True
        Me.RadioTodas.Location = New System.Drawing.Point(16, 15)
        Me.RadioTodas.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioTodas.Name = "RadioTodas"
        Me.RadioTodas.Size = New System.Drawing.Size(69, 21)
        Me.RadioTodas.TabIndex = 0
        Me.RadioTodas.TabStop = True
        Me.RadioTodas.Text = "Todas"
        Me.RadioTodas.UseVisualStyleBackColor = True
        '
        'RadioPendientes
        '
        Me.RadioPendientes.AutoSize = True
        Me.RadioPendientes.Location = New System.Drawing.Point(97, 15)
        Me.RadioPendientes.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioPendientes.Name = "RadioPendientes"
        Me.RadioPendientes.Size = New System.Drawing.Size(100, 21)
        Me.RadioPendientes.TabIndex = 1
        Me.RadioPendientes.TabStop = True
        Me.RadioPendientes.Text = "Pendientes"
        Me.RadioPendientes.UseVisualStyleBackColor = True
        '
        'RadioFinalizadas
        '
        Me.RadioFinalizadas.AutoSize = True
        Me.RadioFinalizadas.Location = New System.Drawing.Point(209, 15)
        Me.RadioFinalizadas.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioFinalizadas.Name = "RadioFinalizadas"
        Me.RadioFinalizadas.Size = New System.Drawing.Size(100, 21)
        Me.RadioFinalizadas.TabIndex = 3
        Me.RadioFinalizadas.TabStop = True
        Me.RadioFinalizadas.Text = "Finalizadas"
        Me.RadioFinalizadas.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Descripcion, Me.Observacion, Me.Autorizado, Me.Solicita, Me.Prioridad, Me.Estados, Me.cambiar, Me.AgregarObservaciones})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(16, 55)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1753, 671)
        Me.DataGridView1.TabIndex = 4
        '
        'RadioProceso
        '
        Me.RadioProceso.AutoSize = True
        Me.RadioProceso.Location = New System.Drawing.Point(328, 15)
        Me.RadioProceso.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioProceso.Name = "RadioProceso"
        Me.RadioProceso.Size = New System.Drawing.Size(102, 21)
        Me.RadioProceso.TabIndex = 5
        Me.RadioProceso.TabStop = True
        Me.RadioProceso.Text = "En Proceso"
        Me.RadioProceso.UseVisualStyleBackColor = True
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Width = 80
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 300
        '
        'Observacion
        '
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        '
        'Autorizado
        '
        Me.Autorizado.HeaderText = "Autorizado"
        Me.Autorizado.Name = "Autorizado"
        Me.Autorizado.Width = 60
        '
        'Solicita
        '
        Me.Solicita.HeaderText = "Solicita"
        Me.Solicita.Name = "Solicita"
        Me.Solicita.Width = 150
        '
        'Prioridad
        '
        Me.Prioridad.HeaderText = "Prioridad"
        Me.Prioridad.Name = "Prioridad"
        '
        'Estados
        '
        Me.Estados.HeaderText = "Estados"
        Me.Estados.Name = "Estados"
        Me.Estados.ReadOnly = True
        '
        'cambiar
        '
        Me.cambiar.HeaderText = ""
        Me.cambiar.Name = "cambiar"
        Me.cambiar.Text = "Cambiar Estado"
        Me.cambiar.UseColumnTextForButtonValue = True
        '
        'AgregarObservaciones
        '
        Me.AgregarObservaciones.HeaderText = ""
        Me.AgregarObservaciones.Name = "AgregarObservaciones"
        Me.AgregarObservaciones.Text = "Observaciones"
        Me.AgregarObservaciones.UseColumnTextForButtonValue = True
        '
        'FormVerSolicitudes_IT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1782, 740)
        Me.Controls.Add(Me.RadioProceso)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.RadioFinalizadas)
        Me.Controls.Add(Me.RadioPendientes)
        Me.Controls.Add(Me.RadioTodas)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormVerSolicitudes_IT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitudes IT"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioTodas As System.Windows.Forms.RadioButton
    Friend WithEvents RadioPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents RadioFinalizadas As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents RadioProceso As System.Windows.Forms.RadioButton
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Autorizado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Solicita As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prioridad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estados As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cambiar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents AgregarObservaciones As System.Windows.Forms.DataGridViewButtonColumn
End Class
