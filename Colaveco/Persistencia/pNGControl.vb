Public Class pNGControl
    Inherits Conectoras.ConexionMySQLGestor


    Public Function guardarControl(ByVal o As Object) As Boolean
        Dim obj As dNGControl = CType(o, dNGControl)


        Dim sql As String = "INSERT INTO Control (ControlId, ControlFechaRealizado, InformeId, ControlTipoId, ControlResultado, ControlCoincide, ControlOpcMejora, ControlNoConformidad, ControlObservaciones, UsuarioId, ControlFechaIngreso, ControlControlado, ControlInformeTipo) VALUES (" & obj.ControlId & ", '" & obj.ControlFechaRealizado & "'," & obj.InformeId & ", " & obj.ControlTipoId & "," & obj.ControlResultado & "," & obj.ControlCoincide & "," & obj.ControlOpcMejora & "," & obj.ControlNoConformidad & ", '" & obj.ControlObservaciones & "', " & obj.UsuarioId & ", '" & obj.ControlFechaIngreso & "', " & obj.ControlControlado & "," & obj.ControlInformeTipo & ")" ')"
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function modificarControl(ByVal o As Object) As Boolean
        Dim obj As dNGControl = CType(o, dNGControl)
        Dim sql As String = "UPDATE Control SET ControlControlado =" & obj.ControlControlado & ", ControlFechaRealizado = '" & obj.ControlFechaRealizado & "' WHERE InformeId = " & obj.InformeId & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function

    Public Function coincideControl(ByVal o As Object) As Boolean
        Dim obj As dNGControl = CType(o, dNGControl)
        Dim sql As String = "UPDATE Control SET ControlCoincide =" & obj.ControlCoincide & "  WHERE InformeId = " & obj.InformeId & ""
        Dim lista As New ArrayList
        lista.Add(sql)
        Return EjecutarTransaccion(lista)
    End Function
End Class
