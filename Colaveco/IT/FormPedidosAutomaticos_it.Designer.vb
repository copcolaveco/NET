<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPedidosAutomaticos_it
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
        Me.NumericDia = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonActivar = New System.Windows.Forms.Button()
        CType(Me.NumericDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Activar pedidos automáticos"
        '
        'NumericDia
        '
        Me.NumericDia.Location = New System.Drawing.Point(61, 61)
        Me.NumericDia.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.NumericDia.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericDia.Name = "NumericDia"
        Me.NumericDia.Size = New System.Drawing.Size(57, 20)
        Me.NumericDia.TabIndex = 1
        Me.NumericDia.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Día"
        '
        'ButtonActivar
        '
        Me.ButtonActivar.Location = New System.Drawing.Point(124, 58)
        Me.ButtonActivar.Name = "ButtonActivar"
        Me.ButtonActivar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonActivar.TabIndex = 3
        Me.ButtonActivar.Text = "Activar"
        Me.ButtonActivar.UseVisualStyleBackColor = True
        '
        'FormPedidosAutomaticos_it
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(253, 93)
        Me.Controls.Add(Me.ButtonActivar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericDia)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormPedidosAutomaticos_it"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos Automáticos"
        CType(Me.NumericDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericDia As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonActivar As System.Windows.Forms.Button
End Class
