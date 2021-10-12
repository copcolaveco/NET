<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSincronizaFichaCaravana
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSincronizaFichaCaravana))
        Me.TextFicha = New System.Windows.Forms.TextBox
        Me.ButtonSeleccionarArchivo = New System.Windows.Forms.Button
        Me.TextArchivo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonSincronizar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TextFicha
        '
        Me.TextFicha.Location = New System.Drawing.Point(66, 15)
        Me.TextFicha.Name = "TextFicha"
        Me.TextFicha.Size = New System.Drawing.Size(100, 20)
        Me.TextFicha.TabIndex = 0
        '
        'ButtonSeleccionarArchivo
        '
        Me.ButtonSeleccionarArchivo.Location = New System.Drawing.Point(172, 13)
        Me.ButtonSeleccionarArchivo.Name = "ButtonSeleccionarArchivo"
        Me.ButtonSeleccionarArchivo.Size = New System.Drawing.Size(137, 23)
        Me.ButtonSeleccionarArchivo.TabIndex = 1
        Me.ButtonSeleccionarArchivo.Text = "Seleccione el archivo"
        Me.ButtonSeleccionarArchivo.UseVisualStyleBackColor = True
        '
        'TextArchivo
        '
        Me.TextArchivo.Location = New System.Drawing.Point(66, 42)
        Me.TextArchivo.Name = "TextArchivo"
        Me.TextArchivo.Size = New System.Drawing.Size(380, 20)
        Me.TextArchivo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nº Ficha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Archivo"
        '
        'ButtonSincronizar
        '
        Me.ButtonSincronizar.Location = New System.Drawing.Point(190, 104)
        Me.ButtonSincronizar.Name = "ButtonSincronizar"
        Me.ButtonSincronizar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSincronizar.TabIndex = 5
        Me.ButtonSincronizar.Text = "Sincronizar"
        Me.ButtonSincronizar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(207, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(63, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(182, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "El archivo debe ser en formato excel."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(224, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Solo 2 columnas, id - caravana (en ese orden)"
        '
        'FormSincronizaFichaCaravana
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 158)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonSincronizar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextArchivo)
        Me.Controls.Add(Me.ButtonSeleccionarArchivo)
        Me.Controls.Add(Me.TextFicha)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSincronizaFichaCaravana"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sincroniza ficha - caravana"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextFicha As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSeleccionarArchivo As System.Windows.Forms.Button
    Friend WithEvents TextArchivo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonSincronizar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
