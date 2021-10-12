<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDesmarcarInformes
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
        Me.TextFicha = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonAgua = New System.Windows.Forms.Button()
        Me.ButtonAntibiograma = New System.Windows.Forms.Button()
        Me.ButtonBrucelosis = New System.Windows.Forms.Button()
        Me.ButtonSubproductos = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonSuelos = New System.Windows.Forms.Button()
        Me.ButtonNutricion = New System.Windows.Forms.Button()
        Me.ButtonCalidad = New System.Windows.Forms.Button()
        Me.ButtonControl = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(12, 28)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(107, 20)
        Me.TextFicha.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nº de Ficha"
        '
        'ButtonAgua
        '
        Me.ButtonAgua.Location = New System.Drawing.Point(12, 54)
        Me.ButtonAgua.Name = "ButtonAgua"
        Me.ButtonAgua.Size = New System.Drawing.Size(107, 23)
        Me.ButtonAgua.TabIndex = 2
        Me.ButtonAgua.Text = "Agua"
        Me.ButtonAgua.UseVisualStyleBackColor = True
        '
        'ButtonAntibiograma
        '
        Me.ButtonAntibiograma.Location = New System.Drawing.Point(12, 83)
        Me.ButtonAntibiograma.Name = "ButtonAntibiograma"
        Me.ButtonAntibiograma.Size = New System.Drawing.Size(107, 23)
        Me.ButtonAntibiograma.TabIndex = 3
        Me.ButtonAntibiograma.Text = "Antibiograma"
        Me.ButtonAntibiograma.UseVisualStyleBackColor = True
        '
        'ButtonBrucelosis
        '
        Me.ButtonBrucelosis.Location = New System.Drawing.Point(12, 112)
        Me.ButtonBrucelosis.Name = "ButtonBrucelosis"
        Me.ButtonBrucelosis.Size = New System.Drawing.Size(107, 23)
        Me.ButtonBrucelosis.TabIndex = 4
        Me.ButtonBrucelosis.Text = "Brucelosis en leche"
        Me.ButtonBrucelosis.UseVisualStyleBackColor = True
        '
        'ButtonSubproductos
        '
        Me.ButtonSubproductos.Location = New System.Drawing.Point(12, 228)
        Me.ButtonSubproductos.Name = "ButtonSubproductos"
        Me.ButtonSubproductos.Size = New System.Drawing.Size(107, 23)
        Me.ButtonSubproductos.TabIndex = 5
        Me.ButtonSubproductos.Text = "Alimentos"
        Me.ButtonSubproductos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 297)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(251, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Desmarcar fichas para volver a generar los informes"
        '
        'ButtonSuelos
        '
        Me.ButtonSuelos.Location = New System.Drawing.Point(12, 257)
        Me.ButtonSuelos.Name = "ButtonSuelos"
        Me.ButtonSuelos.Size = New System.Drawing.Size(107, 23)
        Me.ButtonSuelos.TabIndex = 7
        Me.ButtonSuelos.Text = "Suelos"
        Me.ButtonSuelos.UseVisualStyleBackColor = True
        '
        'ButtonNutricion
        '
        Me.ButtonNutricion.Location = New System.Drawing.Point(12, 199)
        Me.ButtonNutricion.Name = "ButtonNutricion"
        Me.ButtonNutricion.Size = New System.Drawing.Size(107, 23)
        Me.ButtonNutricion.TabIndex = 8
        Me.ButtonNutricion.Text = "Nutrición"
        Me.ButtonNutricion.UseVisualStyleBackColor = True
        '
        'ButtonCalidad
        '
        Me.ButtonCalidad.Location = New System.Drawing.Point(12, 141)
        Me.ButtonCalidad.Name = "ButtonCalidad"
        Me.ButtonCalidad.Size = New System.Drawing.Size(107, 23)
        Me.ButtonCalidad.TabIndex = 9
        Me.ButtonCalidad.Text = "Calidad"
        Me.ButtonCalidad.UseVisualStyleBackColor = True
        '
        'ButtonControl
        '
        Me.ButtonControl.Location = New System.Drawing.Point(12, 170)
        Me.ButtonControl.Name = "ButtonControl"
        Me.ButtonControl.Size = New System.Drawing.Size(107, 23)
        Me.ButtonControl.TabIndex = 10
        Me.ButtonControl.Text = "Control"
        Me.ButtonControl.UseVisualStyleBackColor = True
        '
        'FormDesmarcarInformes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 356)
        Me.Controls.Add(Me.ButtonControl)
        Me.Controls.Add(Me.ButtonCalidad)
        Me.Controls.Add(Me.ButtonNutricion)
        Me.Controls.Add(Me.ButtonSuelos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonSubproductos)
        Me.Controls.Add(Me.ButtonBrucelosis)
        Me.Controls.Add(Me.ButtonAntibiograma)
        Me.Controls.Add(Me.ButtonAgua)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextFicha)
        Me.Name = "FormDesmarcarInformes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Desmarcar fichas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonAgua As System.Windows.Forms.Button
    Friend WithEvents ButtonAntibiograma As System.Windows.Forms.Button
    Friend WithEvents ButtonBrucelosis As System.Windows.Forms.Button
    Friend WithEvents ButtonSubproductos As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonSuelos As System.Windows.Forms.Button
    Friend WithEvents ButtonNutricion As System.Windows.Forms.Button
    Friend WithEvents ButtonCalidad As System.Windows.Forms.Button
    Friend WithEvents ButtonControl As System.Windows.Forms.Button
End Class
