using UnityEngine;
using DG.Tweening;

namespace Vehicle.ActionsOnVehicle
{
    public class VehicleRepTrail
    {
        static GameObject trailPrefab;
        static GameObject circlePrefab;
        const string PATH_TO_TRAIL= "ReplacedVehicleTrail";
        const string PATH_TO_CIRCLE= "ReplacedVehicleCircle";

        float speedPerMeter;
        Transform from, to;
        GameObject createdTrail;
        GameObject createdCircle;
        static VehicleRepTrail() {
            trailPrefab = UnityEngine.Resources.Load<GameObject>(PATH_TO_TRAIL);
            circlePrefab = UnityEngine.Resources.Load<GameObject>(PATH_TO_CIRCLE);
        }
        public VehicleRepTrail(Transform _from, Transform _to, float _speedPerMeter)
        {
            from = _from;
            to = _to;
            speedPerMeter = _speedPerMeter;
            Create();
        }

        public void Create()
        {
            createdTrail = GameObject.Instantiate(trailPrefab, from.position, Quaternion.identity);
            createdCircle = GameObject.Instantiate(circlePrefab, to);
            createdCircle.transform.localScale = Vector3.zero;

            MoveTrail();
        }
        public void MoveTrail()
        {
            var renderer = createdTrail.GetComponent<LineRenderer>();

            var mat = createdCircle.GetComponent<Renderer>().material;
            var color = mat.GetColor("_BaseColor");

            mat.DOColor(new Color(color.r, color.g, color.b, 0f), .6f);

            createdCircle.transform.DOScale(6f, 2f).OnComplete(() => Object.Destroy(createdCircle));

            DOVirtual.Vector3(from.position, to.position, speedPerMeter, newPos => {
                renderer.SetPosition(0, from.position);
                renderer.SetPosition(1, newPos);
            }).SetEase(Ease.InOutSine).OnComplete(() => Object.Destroy(createdTrail));
        }
    }
}