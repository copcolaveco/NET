<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCambiarVMIBC
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
        Me.Bajo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Alto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Seleccionar = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonMostrarTodas = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha, Me.Bajo, Me.Alto, Me.Seleccionar})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 36)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(404, 293)
        Me.DataGridView1.TabIndex = 0
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
        Me.Fecha.Width = 150
        '
        'Bajo
        '
        Me.Bajo.HeaderText = "Bajo"
        Me.Bajo.Name = "Bajo"
        Me.Bajo.Width = 75
        '
        'Alto
        '
        Me.Alto.HeaderText = "Alto"
        Me.Alto.Name = "Alto"
        Me.Alto.Width = 75
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = ""
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Text = "Seleccionar"
        Me.Seleccionar.UseColumnTextForButtonValue = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Este listado muestra las últimas 10 lecturas."
        '
        'ButtonMostrarTodas
        '
        Me.ButtonMostrarTodas.Location = New System.Drawing.Point(321, 7)
        Me.ButtonMostrarTodas.Name = "ButtonMostrarTodas"
        Me.ButtonMostrarTodas.Size = New System.Drawing.Size(95, 23)
        Me.ButtonMostrarTodas.TabIndex = 2
        Me.ButtonMostrarTodas.Text = "Mostrar todas"
        Me.ButtonMostrarTodas.UseVisualStyleBackColor = True
        '
        'FormCambiarVMIBC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 341)
        Me.Controls.Add(Me.ButtonMostrarTodas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FormCambiarVMIBC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Valores medios Control IBC"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonMostrarTodas As System.Windows.Forms.Button
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bajo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Alto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewButtonColumn
End Class
