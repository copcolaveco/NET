<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompletoATB
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
        Me.ComboAislamiento1 = New System.Windows.Forms.ComboBox()
        Me.ComboAislamiento2 = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Antibiotico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resistencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Completar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Antibiotico2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resistencia2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Completar2 = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboAislamiento1
        '
        Me.ComboAislamiento1.FormattingEnabled = True
        Me.ComboAislamiento1.Location = New System.Drawing.Point(12, 12)
        Me.ComboAislamiento1.Name = "ComboAislamiento1"
        Me.ComboAislamiento1.Size = New System.Drawing.Size(270, 21)
        Me.ComboAislamiento1.TabIndex = 0
        '
        'ComboAislamiento2
        '
        Me.ComboAislamiento2.FormattingEnabled = True
        Me.ComboAislamiento2.Location = New System.Drawing.Point(301, 12)
        Me.ComboAislamiento2.Name = "ComboAislamiento2"
        Me.ComboAislamiento2.Size = New System.Drawing.Size(270, 21)
        Me.ComboAislamiento2.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Antibiotico, Me.Resistencia, Me.Completar})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 39)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(270, 252)
        Me.DataGridView1.TabIndex = 2
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        '
        'Antibiotico
        '
        Me.Antibiotico.HeaderText = "Antibiótico"
        Me.Antibiotico.Name = "Antibiotico"
        Me.Antibiotico.Width = 150
        '
        'Resistencia
        '
        Me.Resistencia.HeaderText = "Resist."
        Me.Resistencia.Name = "Resistencia"
        Me.Resistencia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Resistencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Resistencia.Width = 60
        '
        'Completar
        '
        Me.Completar.HeaderText = ""
        Me.Completar.Name = "Completar"
        Me.Completar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Completar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Completar.Text = "+"
        Me.Completar.UseColumnTextForButtonValue = True
        Me.Completar.Width = 50
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id2, Me.Antibiotico2, Me.Resistencia2, Me.Completar2})
        Me.DataGridView2.Location = New System.Drawing.Point(301, 39)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(270, 252)
        Me.DataGridView2.TabIndex = 3
        '
        'Id2
        '
        Me.Id2.HeaderText = "Id"
        Me.Id2.Name = "Id2"
        Me.Id2.Visible = False
        '
        'Antibiotico2
        '
        Me.Antibiotico2.HeaderText = "Antibiótico"
        Me.Antibiotico2.Name = "Antibiotico2"
        Me.Antibiotico2.Width = 150
        '
        'Resistencia2
        '
        Me.Resistencia2.HeaderText = "Resist."
        Me.Resistencia2.Name = "Resistencia2"
        Me.Resistencia2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Resistencia2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Resistencia2.Width = 60
        '
        'Completar2
        '
        Me.Completar2.HeaderText = ""
        Me.Completar2.Name = "Completar2"
        Me.Completar2.Text = "+"
        Me.Completar2.UseColumnTextForButtonValue = True
        Me.Completar2.Width = 50
        '
        'FormCompletoATB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 303)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ComboAislamiento2)
        Me.Controls.Add(Me.ComboAislamiento1)
        Me.Name = "FormCompletoATB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Completo ATB"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboAislamiento1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAislamiento2 As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Antibiotico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resistencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Completar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Id2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Antibiotico2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Resistencia2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Completar2 As System.Windows.Forms.DataGridViewButtonColumn
End Class
