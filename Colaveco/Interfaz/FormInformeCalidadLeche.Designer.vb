<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeCalidadLeche
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInformeCalidadLeche))
        Me.ListFichas = New System.Windows.Forms.ListBox
        Me.ButtonGenerarInforme = New System.Windows.Forms.Button
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonEcolat = New System.Windows.Forms.Button
        Me.CheckBloqueaEcolat = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'ListFichas
        '
        Me.ListFichas.BackColor = System.Drawing.SystemColors.Info
        Me.ListFichas.FormattingEnabled = True
        Me.ListFichas.Location = New System.Drawing.Point(12, 25)
        Me.ListFichas.Name = "ListFichas"
        Me.ListFichas.Size = New System.Drawing.Size(180, 355)
        Me.ListFichas.TabIndex = 0
        '
        'ButtonGenerarInforme
        '
        Me.ButtonGenerarInforme.Location = New System.Drawing.Point(198, 51)
        Me.ButtonGenerarInforme.Name = "ButtonGenerarInforme"
        Me.ButtonGenerarInforme.Size = New System.Drawing.Size(108, 23)
        Me.ButtonGenerarInforme.TabIndex = 1
        Me.ButtonGenerarInforme.Text = "Generar informe"
        Me.ButtonGenerarInforme.UseVisualStyleBackColor = True
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(198, 25)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(108, 20)
        Me.TextFicha.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nº Ficha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fichas"
        '
        'ButtonEcolat
        '
        Me.ButtonEcolat.Location = New System.Drawing.Point(198, 345)
        Me.ButtonEcolat.Name = "ButtonEcolat"
        Me.ButtonEcolat.Size = New System.Drawing.Size(108, 35)
        Me.ButtonEcolat.TabIndex = 5
        Me.ButtonEcolat.Text = "Solo actualiza base de datos Ecolat"
        Me.ButtonEcolat.UseVisualStyleBackColor = True
        '
        'CheckBloqueaEcolat
        '
        Me.CheckBloqueaEcolat.AutoSize = True
        Me.CheckBloqueaEcolat.Location = New System.Drawing.Point(198, 177)
        Me.CheckBloqueaEcolat.Name = "CheckBloqueaEcolat"
        Me.CheckBloqueaEcolat.Size = New System.Drawing.Size(135, 17)
        Me.CheckBloqueaEcolat.TabIndex = 6
        Me.CheckBloqueaEcolat.Text = "Bloquea interfaz Ecolat"
        Me.CheckBloqueaEcolat.UseVisualStyleBackColor = True
        '
        'FormInformeCalidadLeche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 393)
        Me.Controls.Add(Me.CheckBloqueaEcolat)
        Me.Controls.Add(Me.ButtonEcolat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFicha)
        Me.Controls.Add(Me.ButtonGenerarInforme)
        Me.Controls.Add(Me.ListFichas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormInformeCalidadLeche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de calidad de leche"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListFichas As System.Windows.Forms.ListBox
    Friend WithEvents ButtonGenerarInforme As System.Windows.Forms.Button
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonEcolat As System.Windows.Forms.Button
    Friend WithEvents CheckBloqueaEcolat As System.Windows.Forms.CheckBox
End Class
