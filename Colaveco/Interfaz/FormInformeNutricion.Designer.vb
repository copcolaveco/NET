<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeNutricion
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.ButtonGenerarInforme = New System.Windows.Forms.Button
        Me.ListFichas = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Fichas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Nº Ficha"
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(198, 27)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(108, 20)
        Me.TextFicha.TabIndex = 7
        '
        'ButtonGenerarInforme
        '
        Me.ButtonGenerarInforme.Location = New System.Drawing.Point(198, 53)
        Me.ButtonGenerarInforme.Name = "ButtonGenerarInforme"
        Me.ButtonGenerarInforme.Size = New System.Drawing.Size(108, 23)
        Me.ButtonGenerarInforme.TabIndex = 6
        Me.ButtonGenerarInforme.Text = "Generar informe"
        Me.ButtonGenerarInforme.UseVisualStyleBackColor = True
        '
        'ListFichas
        '
        Me.ListFichas.BackColor = System.Drawing.SystemColors.Info
        Me.ListFichas.FormattingEnabled = True
        Me.ListFichas.Location = New System.Drawing.Point(12, 27)
        Me.ListFichas.Name = "ListFichas"
        Me.ListFichas.Size = New System.Drawing.Size(180, 355)
        Me.ListFichas.TabIndex = 5
        '
        'FormInformeNutricion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 397)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.ButtonGenerarInforme)
        Me.Controls.Add(Me.ListFichas)
        Me.Name = "FormInformeNutricion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de nutrición"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGenerarInforme As System.Windows.Forms.Button
    Friend WithEvents ListFichas As System.Windows.Forms.ListBox
End Class
