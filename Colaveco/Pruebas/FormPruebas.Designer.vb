<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPruebas
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
        Me.Button10 = New System.Windows.Forms.Button()
        Me.ButtonActualizarIdNet = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.DateCtaCte = New System.Windows.Forms.DateTimePicker()
        Me.Button28 = New System.Windows.Forms.Button()
        Me.Button29 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(161, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(275, 215)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 5
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(12, 12)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(216, 23)
        Me.Button10.TabIndex = 21
        Me.Button10.Text = "Borrar compras sin línea de compra"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'ButtonActualizarIdNet
        '
        Me.ButtonActualizarIdNet.Location = New System.Drawing.Point(12, 70)
        Me.ButtonActualizarIdNet.Name = "ButtonActualizarIdNet"
        Me.ButtonActualizarIdNet.Size = New System.Drawing.Size(216, 23)
        Me.ButtonActualizarIdNet.TabIndex = 37
        Me.ButtonActualizarIdNet.Text = "Actualizar idnet en la web"
        Me.ButtonActualizarIdNet.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(12, 41)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(216, 23)
        Me.Button16.TabIndex = 38
        Me.Button16.Text = "Borrar lineas de compra sin compra"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(12, 99)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(216, 23)
        Me.Button19.TabIndex = 41
        Me.Button19.Text = "Unifica nombre NET - WEB"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'Button24
        '
        Me.Button24.Location = New System.Drawing.Point(12, 196)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(122, 23)
        Me.Button24.TabIndex = 47
        Me.Button24.Text = "Subir cta cte x dia"
        Me.Button24.UseVisualStyleBackColor = True
        '
        'DateCtaCte
        '
        Me.DateCtaCte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateCtaCte.Location = New System.Drawing.Point(12, 170)
        Me.DateCtaCte.Name = "DateCtaCte"
        Me.DateCtaCte.Size = New System.Drawing.Size(115, 20)
        Me.DateCtaCte.TabIndex = 48
        '
        'Button28
        '
        Me.Button28.Location = New System.Drawing.Point(12, 225)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(122, 23)
        Me.Button28.TabIndex = 55
        Me.Button28.Text = "Subir informes por dia"
        Me.Button28.UseVisualStyleBackColor = True
        '
        'Button29
        '
        Me.Button29.Location = New System.Drawing.Point(12, 294)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(216, 31)
        Me.Button29.TabIndex = 56
        Me.Button29.Text = "Subir clientes al gestor nuevo"
        Me.Button29.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 331)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(216, 23)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "Marcar cajas como recibidas"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(402, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(184, 23)
        Me.Button2.TabIndex = 58
        Me.Button2.Text = "Convenio RC"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(402, 42)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(184, 23)
        Me.Button3.TabIndex = 59
        Me.Button3.Text = "Clientes por empresa"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FormPruebas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 557)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button29)
        Me.Controls.Add(Me.Button28)
        Me.Controls.Add(Me.DateCtaCte)
        Me.Controls.Add(Me.Button24)
        Me.Controls.Add(Me.Button19)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.ButtonActualizarIdNet)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormPruebas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pruebas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents ButtonActualizarIdNet As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents DateCtaCte As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button28 As System.Windows.Forms.Button
    Friend WithEvents Button29 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
