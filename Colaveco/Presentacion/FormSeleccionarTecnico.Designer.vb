﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSeleccionarTecnico
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
        Me.CheckBoxDiego = New System.Windows.Forms.CheckBox
        Me.CheckBoxClaudia = New System.Windows.Forms.CheckBox
        Me.CheckBoxLorena = New System.Windows.Forms.CheckBox
        Me.CheckBoxErika = New System.Windows.Forms.CheckBox
        Me.ButtonGuardar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CheckBoxDiego
        '
        Me.CheckBoxDiego.AutoSize = True
        Me.CheckBoxDiego.Location = New System.Drawing.Point(12, 12)
        Me.CheckBoxDiego.Name = "CheckBoxDiego"
        Me.CheckBoxDiego.Size = New System.Drawing.Size(90, 17)
        Me.CheckBoxDiego.TabIndex = 0
        Me.CheckBoxDiego.Text = "Diego Arenas"
        Me.CheckBoxDiego.UseVisualStyleBackColor = True
        '
        'CheckBoxClaudia
        '
        Me.CheckBoxClaudia.AutoSize = True
        Me.CheckBoxClaudia.Location = New System.Drawing.Point(12, 35)
        Me.CheckBoxClaudia.Name = "CheckBoxClaudia"
        Me.CheckBoxClaudia.Size = New System.Drawing.Size(97, 17)
        Me.CheckBoxClaudia.TabIndex = 1
        Me.CheckBoxClaudia.Text = "Claudia García"
        Me.CheckBoxClaudia.UseVisualStyleBackColor = True
        '
        'CheckBoxLorena
        '
        Me.CheckBoxLorena.AutoSize = True
        Me.CheckBoxLorena.Location = New System.Drawing.Point(12, 58)
        Me.CheckBoxLorena.Name = "CheckBoxLorena"
        Me.CheckBoxLorena.Size = New System.Drawing.Size(105, 17)
        Me.CheckBoxLorena.TabIndex = 2
        Me.CheckBoxLorena.Text = "Lorena Nidegger"
        Me.CheckBoxLorena.UseVisualStyleBackColor = True
        '
        'CheckBoxErika
        '
        Me.CheckBoxErika.AutoSize = True
        Me.CheckBoxErika.Location = New System.Drawing.Point(12, 81)
        Me.CheckBoxErika.Name = "CheckBoxErika"
        Me.CheckBoxErika.Size = New System.Drawing.Size(76, 17)
        Me.CheckBoxErika.TabIndex = 3
        Me.CheckBoxErika.Text = "Erika Silva"
        Me.CheckBoxErika.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Location = New System.Drawing.Point(83, 114)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGuardar.TabIndex = 4
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'FormSeleccionarTecnico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(231, 149)
        Me.Controls.Add(Me.ButtonGuardar)
        Me.Controls.Add(Me.CheckBoxErika)
        Me.Controls.Add(Me.CheckBoxLorena)
        Me.Controls.Add(Me.CheckBoxClaudia)
        Me.Controls.Add(Me.CheckBoxDiego)
        Me.Name = "FormSeleccionarTecnico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Técnico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBoxDiego As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxClaudia As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxLorena As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxErika As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
End Class
