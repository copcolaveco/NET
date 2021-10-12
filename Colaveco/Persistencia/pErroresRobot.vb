Public Class pErroresRobot
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dErroresRobot = CType(o, dErroresRobot)
        Dim sql As String = "INSERT INTO errores_robot (id, fecha, hora, descripcion, visto) VALUES (" & obj.ID & ", '" & obj.FECHA & "', '" & obj.HORA & "', '" & obj.DESCRIPCION & "', " & obj.VISTO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dErroresRobot = CType(o, dErroresRobot)
        Dim sql As String = "UPDATE errores_robot SET fecha = '" & obj.FECHA & "',hora = '" & obj.HORA & "',descripcion = '" & obj.DESCRIPCION & "',visto = " & obj.VISTO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dErroresRobot = CType(o, dErroresRobot)
        Dim sql As String = "DELETE FROM errores_robot WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dErroresRobot
        Dim obj As dErroresRobot = CType(o, dErroresRobot)
        Dim l As New dErroresRobot
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, hora, descripcion, visto FROM errores_robot WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.FECHA = CType(unaFila.Item(1), String)
                l.HORA = CType(unaFila.Item(2), String)
                l.DESCRIPCION = CType(unaFila.Item(3), String)
                l.VISTO = CType(unaFila.Item(4), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, hora, descripcion, visto FROM errores_robot"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dErroresRobot
                    l.ID = CType(unaFila.Item(0), Long)
                    l.FECHA = CType(unaFila.Item(1), String)
                    l.HORA = CType(unaFila.Item(2), String)
                    l.DESCRIPCION = CType(unaFila.Item(3), String)
                    l.VISTO = CType(unaFila.Item(4), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
