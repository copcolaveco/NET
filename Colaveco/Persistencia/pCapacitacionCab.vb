Public Class pCapacitacionCab
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCapacitacionCab = CType(o, dCapacitacionCab)
        Dim sql As String = "INSERT INTO capacitacion_cab (id, ano, area, objetivos, capacitacion) VALUES (" & obj.ID & ", " & obj.ANO & ", " & obj.AREA & ", '" & obj.OBJETIVOS & "', '" & obj.CAPACITACION & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'capacitacion_cab', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCapacitacionCab = CType(o, dCapacitacionCab)
        Dim sql As String = "UPDATE capacitacion_cab SET ano = " & obj.ANO & ", area= " & obj.AREA & ", objetivos='" & obj.OBJETIVOS & "', capacitacion='" & obj.CAPACITACION & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'capacitacion_cab', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCapacitacionCab = CType(o, dCapacitacionCab)
        Dim sql As String = "DELETE FROM capacitacion_cab WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'capacitacion_cab', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCapacitacionCab
        Dim obj As dCapacitacionCab = CType(o, dCapacitacionCab)
        Dim l As New dCapacitacionCab
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ano, area, objetivos, capacitacion FROM capacitacion_cab WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.ANO = CType(unaFila.Item(1), Integer)
                l.AREA = CType(unaFila.Item(2), Integer)
                l.OBJETIVOS = CType(unaFila.Item(3), String)
                l.CAPACITACION = CType(unaFila.Item(4), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ano, area, objetivos, capacitacion FROM capacitacion_cab order by ano desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCapacitacionCab
                    l.ID = CType(unaFila.Item(0), Long)
                    l.ANO = CType(unaFila.Item(1), Integer)
                    l.AREA = CType(unaFila.Item(2), Integer)
                    l.OBJETIVOS = CType(unaFila.Item(3), String)
                    l.CAPACITACION = CType(unaFila.Item(4), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxano(ByVal ano As Long) As ArrayList
        Dim sql As String = "SELECT id, ano, area, objetivos, capacitacion FROM capacitacion_cab WHERE ano = " & ano & " order by ano desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dCapacitacionCab
                    l.ID = CType(unaFila.Item(0), Long)
                    l.ANO = CType(unaFila.Item(1), Integer)
                    l.AREA = CType(unaFila.Item(2), Integer)
                    l.OBJETIVOS = CType(unaFila.Item(3), String)
                    l.CAPACITACION = CType(unaFila.Item(4), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
