<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormExportar
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
        Me.NumericAno = New System.Windows.Forms.NumericUpDown
        Me.ButtonExportar = New System.Windows.Forms.Button
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumericAno
        '
        Me.NumericAno.Location = New System.Drawing.Point(55, 29)
        Me.NumericAno.Maximum = New Decimal(New Integer() {2030, 0, 0, 0})
        Me.NumericAno.Minimum = New Decimal(New Integer() {2013, 0, 0, 0})
        Me.NumericAno.Name = "NumericAno"
        Me.NumericAno.Size = New System.Drawing.Size(65, 20)
        Me.NumericAno.TabIndex = 0
        Me.NumericAno.Value = New Decimal(New Integer() {2013, 0, 0, 0})
        '
        'ButtonExportar
        '
        Me.ButtonExportar.Location = New System.Drawing.Point(143, 22)
        Me.ButtonExportar.Name = "ButtonExportar"
        Me.ButtonExportar.Size = New System.Drawing.Size(83, 31)
        Me.ButtonExportar.TabIndex = 1
        Me.ButtonExportar.Text = "Exportar"
        Me.ButtonExportar.UseVisualStyleBackColor = True
        '
        'FormExportar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 74)
        Me.Controls.Add(Me.ButtonExportar)
        Me.Controls.Add(Me.NumericAno)
        Me.Name = "FormExportar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar"
        CType(Me.NumericAno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NumericAno As System.Windows.Forms.NumericUpDown
    Friend WithEvents ButtonExportar As System.Windows.Forms.Button
End Class
